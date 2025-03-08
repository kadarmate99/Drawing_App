using Drawing_App_v01.Model;
using Drawing_App_v01.Model.ShapeComponents;
using Drawing_App_v01.Presenter.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing_App_v01.Presenter.DrawingStates
{
    internal class RhombusDrawingState : ShapeDrawingStateBase
    {
        public RhombusDrawingState(Color currentColor, int currentLineWidth) : base(currentColor, currentLineWidth) { }

        public override void HandleMouseDown(MainWindowPresenter presenter, DrawingModel model, int x, int y)
        {
            if (!_isDrawing)
            {
                _startPoint = new Node(_currentColor, x, y);
                _isDrawing = true;
            }
            else
            {
                IDrawingCommand drawCommand = new DrawRhombusCommand(_currentColor, _startPoint, _currentLineWidth);
                drawCommand.Execute(model, x, y);
                presenter.View.InvalidateCanvas();
                _isDrawing = false;
            }
        }

        public override void TemporaryDraw(Graphics g)
        {
            if (_isDrawing && _startPoint != null && _currentPoint != null)
            {
                ShapeRhombus rhombus = new ShapeRhombus(_currentColor, _startPoint, _currentPoint, _currentLineWidth);
                rhombus.Draw(g);
            }
        }
    }
}
