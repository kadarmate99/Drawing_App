using Drawing_App_v01.Model;
using Drawing_App_v01.Model.ShapeComponents;
using System.Reflection;

namespace Drawing_App_v01.Presenter.DrawingStates
{
    public abstract class ShapeDrawingStateBase : IDrawingState
    {
        protected Node _startPoint;
        protected Node _currentPoint;
        protected bool _isDrawing;
        protected readonly Color _currentColor;
        protected readonly int _currentLineWidth;

        public ShapeDrawingStateBase(Color currentColor, int currentLineWidth)
        {
            _isDrawing = false;
            _currentColor = currentColor;
            _currentLineWidth = currentLineWidth;
        }

        public abstract void HandleMouseDown(MainWindowPresenter presenter, DrawingModel model, int x, int y);

        public void HandleMouseMove(MainWindowPresenter presenter, DrawingModel model, int x, int y)
        {
            if (_isDrawing)
            {
                _currentPoint = new Node(_currentColor, x, y);
                presenter.View.InvalidateCanvas();
            }
        }

        public abstract void TemporaryDraw(Graphics g);
    }
}
