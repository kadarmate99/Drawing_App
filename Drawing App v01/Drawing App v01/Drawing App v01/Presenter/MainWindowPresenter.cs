using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drawing_App_v01.Model;
using Drawing_App_v01.Model.ShapeComponents;

namespace Drawing_App_v01.Presenter
{
    public class MainWindowPresenter
    {
        //-----------------------------------------------------------------------------
        // Fields
        //-----------------------------------------------------------------------------
        private readonly DrawingModel _drawingModel;
        private ClickMode _clickMode = ClickMode.None; // Enum to keep track of what shape the user wants to define
        private Node? _firstNode = null;  // Stores first point for line drawing
        private Node? _tempSecondNode = null;  // Temporary node for preview line
        private MainWindow _view;

        //-----------------------------------------------------------------------------
        // Constructor  
        //-----------------------------------------------------------------------------
        public MainWindowPresenter(DrawingModel drawingModel)
        {
            _drawingModel = drawingModel;
        }

        //-----------------------------------------------------------------------------
        // Event Handlers
        //-----------------------------------------------------------------------------

        //- - - - -  CanvasPanel related events  - - - - -
        internal void OnCanvasPanel_Paint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            _drawingModel.RenderModel(e.Graphics);

            // Draw temporary object during definition
            // TODO: Not sure if this is the correct place for this code, might needs rethinking
            if (_clickMode == ClickMode.Line && _firstNode != null && _tempSecondNode != null)
            {
                _drawingModel.RenderShape(e.Graphics, new ShapeLine(_firstNode, _tempSecondNode));
            }
            else if (_clickMode == ClickMode.Rectangle && _firstNode != null && _tempSecondNode != null)
            {
                _drawingModel.RenderShape(e.Graphics, new ShapeRectangle(_firstNode, _tempSecondNode));
            }
        }
        internal void OnCanvasPanel_MouseDown(MouseEventArgs e)
        {

            Node tempNode = new Node(e.X, e.Y);

            if (_clickMode == ClickMode.Point)
            {
                _drawingModel.AddShape(tempNode);
            }
            else if (_clickMode == ClickMode.Line)
            {
                if (_firstNode == null)
                {
                    _firstNode = tempNode;
                    _drawingModel.AddShape(tempNode);
                }
                else
                {
                    Node secondNode = tempNode;
                    _drawingModel.AddShape(secondNode);
                    _drawingModel.AddShape(new ShapeLine(_firstNode, secondNode));

                    // Reset for next line
                    _firstNode = null;
                    _tempSecondNode = null;
                }
            }
            else if (_clickMode == ClickMode.Rectangle)
            {
                if (_firstNode == null)
                {
                    _firstNode = tempNode;
                    _drawingModel.AddShape(tempNode);
                }
                else
                {
                    Node secondNode = tempNode;
                    ShapeRectangle rectangle = new ShapeRectangle(_firstNode, secondNode);
                    _drawingModel.AddShape(rectangle);

                    //Creating corner point -
                    //TODO: One point is extra here because on the first click one nod was already created.This needs to be fixed. 
                    _drawingModel.AddShape(new Node(rectangle.CornerPoint_01.X, rectangle.CornerPoint_01.Y));
                    _drawingModel.AddShape(new Node(rectangle.CornerPoint_02.X, rectangle.CornerPoint_02.Y));
                    _drawingModel.AddShape(new Node(rectangle.CornerPoint_03.X, rectangle.CornerPoint_03.Y));
                    _drawingModel.AddShape(new Node(rectangle.CornerPoint_04.X, rectangle.CornerPoint_04.Y));
                    _firstNode = null;
                    _tempSecondNode = null;
                }
            }
                _view.InvalidateCanvas();
        }
        internal void OnCanvasPanel_MouseMove(MouseEventArgs e)
        {
            if (_firstNode != null)
            {
                _tempSecondNode = new Node(e.X, e.Y);
                _view.InvalidateCanvas();
            }
        }

        //- - - - -  Button click related events  - - - - -
        internal void OnBtnPoint_Click()
        {
            _clickMode = ClickMode.Point;
        }
        internal void OnBtnLine_Click()
        {
            _clickMode = ClickMode.Line;
        }
        internal void OnBtnRectangle_Click()
        {
            _clickMode = ClickMode.Rectangle;
        }
        internal void OnBtnClear_Click()
        {
            _clickMode = ClickMode.None;
            _drawingModel.ClearSahpes();
            _view.InvalidateCanvas();
        }

        //- - - - -  Strip Menu click related events  - - - - -
        internal void OnOpenToolStripMenuItem_Click()
        {
            string filePath = FileDialogHelper.OpenFileDialog();
            OpenFile(filePath);
        }
        internal void OnSaveToolStripMenuItem_Click()
        {
            SaveFile();
        }
        internal void OnSaveAsToolStripMenuItem_Click()
        {
            string filePath = FileDialogHelper.SaveFileDialog();
            SaveAsFile(filePath);
        }

        //- - - - -  WelcomeForm related events  - - - - -
        internal void OnFileSelectedToOpen(object sender, string filePath)
        {
            OpenFile(filePath);
        }

        internal void OnFileSelectedToCreate(object? sender, string filePath)
        {
            SaveAsFile(filePath);
        }

        //-----------------------------------------------------------------------------
        // Methods
        //-----------------------------------------------------------------------------
        public void SetView(MainWindow view) // Method to access the MainWindow (view)
        {
            _view = view;
        }

        private void OpenFile(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                _drawingModel.SetFilePath(filePath);
                FileSerializationService fileSerializationService = new FileSerializationService();
                try
                {
                    List<Shape> shapes = fileSerializationService.LoadDrawingFromFile(filePath);
                    _drawingModel.ClearSahpes(); // Clear existing shapes
                    foreach (var shape in shapes)
                    {
                        _drawingModel.AddShape(shape);
                    }
                    _view.InvalidateCanvas();
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void SaveFile()
        {
            string filePath = _drawingModel.FilePath;
            if (!string.IsNullOrEmpty(filePath))
            {
                _drawingModel.SetFilePath(filePath);
                FileSerializationService fileSerializationService = new FileSerializationService();
                fileSerializationService.SaveDrawingToFile(filePath, _drawingModel.Shapes);
            }
        }

        private void SaveAsFile(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                _drawingModel.SetFilePath(filePath);
                FileSerializationService fileSerializationService = new FileSerializationService();
                fileSerializationService.SaveDrawingToFile(filePath, _drawingModel.Shapes);
            }
        }


    }
}
