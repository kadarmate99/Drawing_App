using Drawing_App_v01.Model;
using Drawing_App_v01.Model.ShapeComponents;

namespace Drawing_App_v01.Presenter.DrawingStates
{
    public abstract class ShapeDrawingStateBase : IDrawingState
    {
        protected Node _startPoint;
        protected Node _currentPoint;
        protected bool _isDrawing;

        public ShapeDrawingStateBase()
        {
            _isDrawing = false;
        }

        public abstract void HandleMouseDown(MainWindowPresenter presenter, DrawingModel model, int x, int y);

        public abstract void HandleMouseMove(MainWindowPresenter presenter, DrawingModel model, int x, int y);

        public abstract void TemporaryDraw(Graphics g);
    }
}
