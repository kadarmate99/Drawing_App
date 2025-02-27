using Drawing_App_v01.Model;
using Drawing_App_v01.Presenter.Commands;
namespace Drawing_App_v01.Presenter.DrawingStates
{
    /// <summary>
    /// Implements IDrawingState to handle drawing points.
    /// Creates and executes a DrawNodeCommand on each mouse click.
    /// </summary>
    public class PointDrawingState : IDrawingState
    {
        public void HandleMouseDown(MainWindowPresenter presenter, DrawingModel model, int x, int y)
        {
            IDrawingCommand drawCommand = new DrawNodeCommand();
            drawCommand.Execute(model, x, y);
            presenter.View.InvalidateCanvas();
        }

        public void HandleMouseMove(MainWindowPresenter presenter, DrawingModel model, int x, int y)
        {
            // Nothing happens for point on mouse move
        }
    }
}
