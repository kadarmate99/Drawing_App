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
        public DrawLineCommand(Node startPoint)
        {
            _startPoint = startPoint;
        }

        public void Execute(DrawingModel model, int x, int y)
        {
            if (_startPoint != null)
            {
                ShapeLine line = new ShapeLine(_startPoint, new Node(x, y));
                model.AddShape(line);
            }
        }
    }
}
