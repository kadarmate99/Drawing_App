using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drawing_App_v01.ShapeComponents;

namespace Drawing_App_v01
{
    public class MainWindowPresenter
    {
        //-----------------------------------------------------------------------------
        // Fields
        //-----------------------------------------------------------------------------
        private readonly DrawingModel _drawingModel;
        private string _clickType;
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
            _drawingModel.Render(e.Graphics);

            // Draw temporary line when defining a new line
            if (_clickType == "line" && _firstNode != null && _tempSecondNode != null)
            {
                e.Graphics.DrawLine(Pens.Black, _firstNode.X, _firstNode.Y, _tempSecondNode.X, _tempSecondNode.Y);
            }
        }
        internal void OnCanvasPanel_MouseDown(MouseEventArgs e)
        {

            Node tempNode = new Node(e.X, e.Y);

            if (_clickType == "point")
            {
                _drawingModel.AddShape(tempNode);
            }
            else if (_clickType == "line")
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
                    _drawingModel.AddShape(new Line(_firstNode, secondNode));

                    // Reset for next line
                    _firstNode = null;
                    _tempSecondNode = null;
                }
            }

            _view.InvalidateCanvas();
        }
        internal void OnCanvasPanel_MouseMove(MouseEventArgs e)
        {
            if (_clickType == "line" && _firstNode != null)
            {
                _tempSecondNode = new Node(e.X, e.Y);
                _view.InvalidateCanvas();
            }
        }

        //- - - - -  Button click related events  - - - - -
        internal void OnBtnPoint_Click()
        {
            _clickType = "point";
        }
        internal void OnBtnLine_Click()
        {
            _clickType = "line";
        }
        internal void OnBtnClear_Click()
        {
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
