using Drawing_App_v01.Model;
using Drawing_App_v01.Model.ShapeComponents;

namespace Drawing_App_v01.Presenter.Commands
{

    /// <summary>
    /// Defines the interface for drawing commands (e.g., DrawNodeCommand, DrawLineCommand).
    /// Enables decoupling drawing actions for undo/redo and command queuing.
    /// </summary>
    public interface IDrawingCommand
    {
        void Execute(DrawingModel model, int x, int y);
    }
}
