using Drawing_App_v01.Model;
using Drawing_App_v01.Model.ShapeComponents;

namespace Drawing_App_v01.Presenter.Commands
{
    /// <summary>
    /// Implements IDrawingCommand to draw a rectangle on the canvas.
    /// Stores the first corner and draws the rectangle to the specified coordinates on the next execution.
    /// </summary>
    public class DrawRectangleCommand : IDrawingCommand
    {
        private Node _startPoint;
        private Color _currentColor;
        private int _currentLineWidth;

        public DrawRectangleCommand(Color currentColor, Node startPoint, int currentLineWidth)
        {
            _startPoint = startPoint;
            _currentColor = currentColor;
            _currentLineWidth = currentLineWidth;
        }

        public void Execute(DrawingModel model, int x, int y)
        {
            if (_startPoint != null)
            {
                ShapeRectangle rectangle = new ShapeRectangle(_currentColor, _startPoint, new Node(_currentColor, x, y), _currentLineWidth);
                model.AddShape(rectangle);
            }
        }
    }
}
