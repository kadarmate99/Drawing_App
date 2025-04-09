﻿using Drawing_App_v01.Model;
using Drawing_App_v01.Model.ShapeComponents;
using Drawing_App_v01.Presenter.Commands;

namespace Drawing_App_v01.Presenter.DrawingStates

{
    /// <summary>
    /// Drawing state for creating lines between two points.
    /// </summary>
    public class LineDrawingState : ShapeDrawingStateBase
    {
        public LineDrawingState(DrawingSettings drawingSettings) : base(drawingSettings) {}

        public override void HandleMouseDown(MainWindowPresenter presenter, DrawingModel model, int x, int y)
        {
            if (!_isDrawing)
            {
                _startPoint = new Node(_drawingSettings.DrawingColor, x, y);
                _isDrawing = true;
            }
            else
            {
                IDrawingCommand drawCommand = new DrawLineCommand(_drawingSettings.DrawingColor, _startPoint, _drawingSettings.DrawingLineWidth);
                drawCommand.Execute(model, x, y);
                presenter.View.InvalidateCanvas();
                _isDrawing=false;
            }
        }

        public override void TemporaryDraw(Graphics g)
        {
            if (_isDrawing && _startPoint != null && _currentPoint != null)
            {
                ShapeLine line = new ShapeLine(_drawingSettings.DrawingColor, _startPoint, _currentPoint, _drawingSettings.DrawingLineWidth);
                line.Draw(g);
            }
        }
    }
}
