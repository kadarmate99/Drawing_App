using Drawing_App_v01.Model;
using Drawing_App_v01.Model.ShapeComponents;
using Drawing_App_v01.Presenter.Commands;

namespace Drawing_App_v01.Presenter.DrawingStates
{
    public class RectangleDrawingState : IDrawingState
    {
        private Node _startPoint;
        private Node _currentPoint;
        private bool _isDrawing;

        public RectangleDrawingState()
        {
            _isDrawing = false;
        }

        public void HandleMouseDown(MainWindowPresenter presenter, DrawingModel model, int x, int y)
        {
            if (!_isDrawing)
            {
                _startPoint = new Node(x, y);
                _isDrawing = true;
            }
            else
            {
                IDrawingCommand drawCommand = new DrawRectangleCommand(_startPoint);
                drawCommand.Execute(model, x, y);
                presenter.View.InvalidateCanvas();
                _isDrawing = false;
            }
        }

        public void HandleMouseMove(MainWindowPresenter presenter, DrawingModel model, int x, int y)
        {
            if (_isDrawing)
            {
                _currentPoint = new Node(x, y);
                presenter.View.InvalidateCanvas();
            }
        }

        internal void DrawTemporaryRectangle(Graphics graphics)
        {
            if (_isDrawing && _startPoint != null && _currentPoint != null)
            {
                ShapeRectangle rectangle = new ShapeRectangle(_startPoint, _currentPoint);
                rectangle.Draw(graphics);
            }
        }
    }
}
