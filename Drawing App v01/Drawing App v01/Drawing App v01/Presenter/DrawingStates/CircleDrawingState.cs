using Drawing_App_v01.Model;
using Drawing_App_v01.Model.ShapeComponents;
using Drawing_App_v01.Presenter.Commands;

namespace Drawing_App_v01.Presenter.DrawingStates
{
    internal class CircleDrawingState : ShapeDrawingStateBase
    {
        public CircleDrawingState(Color currentColor) : base(currentColor) { }
        public override void HandleMouseDown(MainWindowPresenter presenter, DrawingModel model, int x, int y)
        {
            if (!_isDrawing)
            {
                _startPoint = new Node(_currentColor, x, y);
                _isDrawing = true;
            }
            else
            {
                IDrawingCommand drawCommand = new DrawCircleCommand(_currentColor, _startPoint);
                drawCommand.Execute(model, x, y);
                presenter.View.InvalidateCanvas();
                _isDrawing = false;
            }
        }

        public override void TemporaryDraw(Graphics g)
        {
            if (_isDrawing && _startPoint != null && _currentPoint != null)
            {
                ShapeCircle circle = new ShapeCircle(_currentColor, _startPoint, _currentPoint);
               circle.Draw(g);
            }
        }
    }
}