using Drawing_App_v01.Model;
using Drawing_App_v01.Model.ShapeComponents;

namespace Drawing_App_v01.Presenter.Commands
{

    /// <summary>
    /// Defines the interface for drawing commands. Enables command pattern implementation
    /// for drawing operations.
    /// </summary>
    public interface IDrawingCommand
    {
        /// <summary>
        /// Executes the drawing command on the specified model at the given coordinates.
        /// </summary>
        /// <param name="model">The drawing model to modify.</param>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        void Execute(DrawingModel model, int x, int y);
    }
}
