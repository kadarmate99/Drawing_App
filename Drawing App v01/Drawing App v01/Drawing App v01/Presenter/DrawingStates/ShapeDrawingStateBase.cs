using Drawing_App_v01.Model;
using Drawing_App_v01.Model.ShapeComponents;
using System.Reflection;

namespace Drawing_App_v01.Presenter.DrawingStates
{
    /// <summary>
    /// Base class for drawing states that create shapes requiring multiple points.
    /// Manages the drawing process across multiple mouse clicks.
    /// </summary>
    public abstract class ShapeDrawingStateBase : IDrawingState
    {
        protected Node _startPoint;
        protected Node _currentPoint;
        protected bool _isDrawing;
        protected readonly DrawingSettings _drawingSettings;

        public ShapeDrawingStateBase(DrawingSettings drawingSettings)
        {
            _isDrawing = false;
            _drawingSettings = drawingSettings;
        }

        public abstract void HandleMouseDown(MainWindowPresenter presenter, DrawingModel model, int x, int y);

        /// <summary>
        /// Handles mouse movement events, updating temporary shape visualization.
        /// </summary>
        /// <param name="presenter">The presenter controlling the drawing.</param>
        /// <param name="model">The drawing model.</param>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public void HandleMouseMove(MainWindowPresenter presenter, DrawingModel model, int x, int y)
        {
            if (_isDrawing)
            {
                _currentPoint = new Node(_drawingSettings.DrawingColor, x, y);
                presenter.View.InvalidateCanvas();
            }
        }

        /// <summary>
        /// Draws the temporary shape preview during the drawing process.
        /// </summary>
        /// <param name="g">The graphics context to draw on.</param>
        public abstract void TemporaryDraw(Graphics g);
    }
}
