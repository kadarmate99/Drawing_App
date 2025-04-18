﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drawing_App_v01.Model;
using Drawing_App_v01.Model.ShapeComponents;
using Drawing_App_v01.Presenter.DrawingStates;
using Drawing_App_v01.View;

namespace Drawing_App_v01.Presenter
{
    /// <summary>
    /// Coordinates interaction between the main window view and the drawing model.
    /// Handles user input and manages drawing states.
    /// </summary>
    public class MainWindowPresenter
    {
        //-----------------------------------------------------------------------------
        // Fields
        //-----------------------------------------------------------------------------
        private readonly DrawingModel _drawingModel;
        private MainWindow _view;
        private IDrawingState _currentDrawingState;
        private readonly DrawingSettings _drawingSettings = new DrawingSettings();
        private ToolTip toolTip = new ToolTip();

        //-----------------------------------------------------------------------------
        //Properties 
        //-----------------------------------------------------------------------------

        //Provide ways for external code to interact with the class safely, rather than directly accessing the fields.
        public MainWindow View => _view;
        public IDrawingState CurrentDrawingState
        {
            get => _currentDrawingState;
            set => _currentDrawingState = value;
        }
        public DrawingSettings DrawingSettings => _drawingSettings;

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

        /// <summary>
        /// Handles paint events for the canvas, rendering the model and any temporary shapes.
        /// </summary>
        /// <param name="e">The paint event arguments.</param>
        internal void OnCanvasPanel_Paint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Apply transformations before drawing
            e.Graphics.TranslateTransform(_view.Canvas.Offset.X, _view.Canvas.Offset.Y);
            e.Graphics.ScaleTransform(_view.Canvas.Zoom, _view.Canvas.Zoom);

            _drawingModel.RenderModel(e.Graphics);

            if (_currentDrawingState is ShapeDrawingStateBase shapeState)
            {
                shapeState.TemporaryDraw(e.Graphics);
            }
        }
        internal void OnCanvasPanel_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point worldPoint = _view.Canvas.ScreenToWorld(new Point(e.X, e.Y));

                _currentDrawingState?.HandleMouseDown(this, _drawingModel, worldPoint.X, worldPoint.Y);
            }
        }
        internal void OnCanvasPanel_MouseMove(MouseEventArgs e)
        {
            Point worldPoint = _view.Canvas.ScreenToWorld(new Point(e.X, e.Y));

            if (_currentDrawingState is ShapeDrawingStateBase shapeState)
            {
                shapeState?.HandleMouseMove(this, _drawingModel, worldPoint.X, worldPoint.Y);
            }

            if (!_view.Canvas.IsPanning) // This if prevents the cursor to default reset during panning
            {
                foreach (var shape in _drawingModel.Shapes)
                {
                    if (shape.IsNear(worldPoint, 5)) // Check if the mouse is close to a shape
                    {

                        // Show the tooltip for the first time
                        toolTip.Show(shape.ShapeName, _view.Canvas, e.X + 15, e.Y + 15); // Small offset to avoid overlap

                        // Change cursor when hovering over a shape
                        _view.Canvas.Cursor = Cursors.Hand;
                        return;
                    }
                }

                toolTip.Hide(_view.Canvas); // Hide tooltip if no shape is near


                // Reset the cursor if not hovering over a shape
                _view.Canvas.Cursor = Cursors.Default;
            }
        }

        //- - - - -  Button click related events  - - - - -
        internal void OnBtnPoint_Click()
        {
            _currentDrawingState = new NodeDrawingState(_drawingSettings);
        }
        internal void OnBtnLine_Click()
        {
            _currentDrawingState = new LineDrawingState(_drawingSettings);
        }
        internal void OnBtnRectangle_Click()
        {
            _currentDrawingState = new RectangleDrawingState(_drawingSettings);
        }
        internal void OnBtnCircle_Click()
        {
            _currentDrawingState = new CircleDrawingState(_drawingSettings);
        }
        internal void BtnRhombus_Click()
        {
            _currentDrawingState = new RhombusDrawingState(_drawingSettings);
        }
        internal void OnBtnClear_Click()
        {
            _drawingModel.ClearShapes();
            _view.InvalidateCanvas();
        }

        //- - - - -  Drawing object property setters (color, line width)  - - - - -
        internal void ColorPanel_DoubleClick()
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            cd.Color = _view.ColorPanel.BackColor;
            cd.AnyColor = true;
            cd.FullOpen = true;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                _view.ColorPanel.BackColor = cd.Color;
                _drawingSettings.DrawingColor = cd.Color;
            }
        }
        internal void OnCmbLineWidth_SelectedIndexChanged(int index)
        {
            _drawingSettings.DrawingLineWidth = index + 1; //Setting line width based on combobox selection, index + 1 is used because box values are concrete and start from 1
        }
        internal void OnCmbNodeSize_SelectedIndexChanged(int index)
        {
            _drawingSettings.DrawingNodeSize = index + 1; //Setting noide size based on combobox selection, index + 1 is used because box values are concrete and start from 1
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

        internal void OnEditUserDataToolStripMenuItem_Click()
        {
            ShowUserDataForm();
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
                try
                {
                    FileSerializationService fileSerializationService = new FileSerializationService();
                    _drawingModel.SetFilePath(filePath);

                    // Load model from file
                    var loadedModel = fileSerializationService.LoadDrawingFromFile(filePath);

                    // Update the existing _drawingModel
                    _drawingModel.ImportDataFrom(loadedModel);

                    // Apply saved zoom and offset
                    _view.Canvas.SetView(_drawingModel.ZoomLevel, _drawingModel.ViewOffset);

                    // Update App name with the opened model name
                    _view.Text = "Drawing App" + " - " + Path.GetFileNameWithoutExtension(_drawingModel.FilePath);


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
                _drawingModel.SetView(_view.Canvas.Zoom, _view.Canvas.Offset);
                FileSerializationService fileSerializationService = new FileSerializationService();
                fileSerializationService.SaveDrawingToFile(filePath, _drawingModel);
            }
        }

        private void SaveAsFile(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                _drawingModel.SetFilePath(filePath);
                _drawingModel.SetView(_view.Canvas.Zoom, _view.Canvas.Offset);
                FileSerializationService fileSerializationService = new FileSerializationService();
                fileSerializationService.SaveDrawingToFile(filePath, _drawingModel);
                // Update App name with the opened model name
                _view.Text = "Drawing App" + " - " + Path.GetFileNameWithoutExtension(_drawingModel.FilePath);
            }
        }


        public void ShowUserDataForm()
        {
            var userDataPresenter = new UserDataPresenter(_drawingModel);
            using (var userDataForm = new UserDataForm(userDataPresenter))
            {
                userDataForm.LoadUserData(_drawingModel);

                if (userDataForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("User data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        
    }
}

