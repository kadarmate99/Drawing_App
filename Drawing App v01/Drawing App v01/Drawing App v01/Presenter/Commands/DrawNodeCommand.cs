using Drawing_App_v01.Model;
using Drawing_App_v01.Model.ShapeComponents;

namespace Drawing_App_v01.Presenter.Commands
{
    /// <summary>
    /// Implements IDrawingCommand to draw a point on the canvas.
    /// Creates a new Node at specified coordinates and adds it to the DrawingModel.
    /// </summary>
    internal class DrawNodeCommand : IDrawingCommand
    {

        private Color _currentColor;
        public DrawNodeCommand(Color currentColor)
        {
            _currentColor = currentColor;
        }

        public void Execute(DrawingModel model, int x, int y)
        {
            Node point = new Node(_currentColor, x, y);
            model.AddShape(point);
        }
    }
}
