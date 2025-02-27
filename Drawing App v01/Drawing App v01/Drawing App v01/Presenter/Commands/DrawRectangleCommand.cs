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

        public DrawRectangleCommand(Node startPoint)
        {
            _startPoint = startPoint;
        }

        public void Execute(DrawingModel model, int x, int y)
        {
            if (_startPoint != null)
            {
                ShapeRectangle rectangle = new ShapeRectangle(_startPoint, new Node(x, y));
                model.AddShape(rectangle);
            }
        }
    }
}
