﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drawing_App_v01.Model;
using Drawing_App_v01.Model.ShapeComponents;
using Drawing_App_v01.Presenter.DrawingStates;

namespace Drawing_App_v01.Presenter
{
    public class MainWindowPresenter
    {
        //-----------------------------------------------------------------------------
        // Fields
        //-----------------------------------------------------------------------------
        private readonly DrawingModel _drawingModel;
        private MainWindow _view;
        private IDrawingState _currentDrawingState;

        //-----------------------------------------------------------------------------
        //Properties 
        //-----------------------------------------------------------------------------

        //Provide ways for external code to interact with the class safely, rather than directly accessing the fields.

        public MainWindow View
        { get { return _view; } }

        public IDrawingState CurrentDrawingState
        {
            get { return _currentDrawingState; }
            set { _currentDrawingState = value; }
        }

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
            _drawingModel.RenderModel(e.Graphics);

            if (_currentDrawingState is ShapeDrawingStateBase shapeState)
            {
                shapeState.TemporaryDraw(e.Graphics);
            }
        }
        internal void OnCanvasPanel_MouseDown(MouseEventArgs e)
        {
            _currentDrawingState?.HandleMouseDown(this, _drawingModel, e.X, e.Y);
        }
        internal void OnCanvasPanel_MouseMove(MouseEventArgs e)
        {
            if (_currentDrawingState is ShapeDrawingStateBase shapeState)
            {
                shapeState?.HandleMouseMove(this, _drawingModel, e.X, e.Y);
            }
        }

        //- - - - -  Button click related events  - - - - -
        internal void OnBtnPoint_Click()
        {
            _currentDrawingState = new NodeDrawingState();
        }
        internal void OnBtnLine_Click()
        {
            _currentDrawingState = new LineDrawingState();
        }
        internal void OnBtnRectangle_Click()
        {
            _currentDrawingState = new RectangleDrawingState();
        }
        internal void OnBtnCircle_Click()
        {
            _currentDrawingState = new CircleDrawingState();
        }
        internal void BtnRhombus_Click()
        {
            _currentDrawingState = new RhombusDrawingState();
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
        public void SetView(MainWindow view) // Method to access the MainWindow (view) through controlled initialization
        {
            if (_view == null)
            {
                _view = view;
            }
        }

        private void OpenFile(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                _drawingModel.SetFilePath(filePath);
                FileSerializationService fileSerializationService = new FileSerializationService();
                try
                {
                    List<ShapeBase> shapes = fileSerializationService.LoadDrawingFromFile(filePath);
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
