using Drawing_App_v01.Model;
using Drawing_App_v01.Model.ShapeComponents;

namespace Drawing_App_v01.Presenter.Commands
{
    /// <summary>
    /// Implements IDrawingCommand to draw a line on the canvas.
    /// Stores a starting point and draws the line to the current coordinates on the next execution.
    /// </summary>
    public class DrawLineCommand : IDrawingCommand
    {
        private Node _startPoint;
        private Color _currentColor;
        private int _currnetLineWidth;
        public DrawLineCommand(Color currentColor, Node startPoint, int currnetLineWidth)
        {
            _startPoint = startPoint;
            _currentColor = currentColor;
            _currnetLineWidth = currnetLineWidth;
        }

        public void Execute(DrawingModel model, int x, int y)
        {
            if (_startPoint != null)
            {
                ShapeLine line = new ShapeLine(_currentColor, _startPoint, new Node(_currentColor, x, y), _currnetLineWidth);
                model.AddShape(line);
            }
        }
    }
}
