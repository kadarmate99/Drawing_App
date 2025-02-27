﻿using Drawing_App_v01.Model;
using Drawing_App_v01.Model.ShapeComponents;
using Drawing_App_v01.Presenter.Commands;

namespace Drawing_App_v01.Presenter.DrawingStates

{
    /// <summary>
    /// Implements IDrawingState to handle drawing lines.
    /// Uses DrawLineCommand to draw a line.
    /// </summary>
    public class LineDrawingState : IDrawingState
    {
        private Node _startPoint;
        private Node _currentPoint;
        private bool _isDrawing;

        public LineDrawingState()
        {
            _isDrawing = false;
        }
        
        public void HandleMouseDown(MainWindowPresenter presenter, DrawingModel model, int x, int y)
        {
            if (!_isDrawing)
            {
                _startPoint = new Node(x,y);
                _isDrawing = true;
            }
            else
            {
                IDrawingCommand drawCommand = new DrawLineCommand(_startPoint);
                drawCommand.Execute(model, x, y);
                presenter.View.InvalidateCanvas();
                _isDrawing=false;
            }
        }

        public void HandleMouseMove(MainWindowPresenter presenter, DrawingModel model, int x, int y)
        {
            if (_isDrawing)
            {
                _currentPoint = new Node(x,y);
                presenter.View.InvalidateCanvas();
            }
        }

        public void DrawTemporaryLine(Graphics g)
        {
            if (_isDrawing && _startPoint != null && _currentPoint != null)
            {
                ShapeLine line = new ShapeLine(_startPoint, _currentPoint);
                line.Draw(g);
            }
        }
    }
}
