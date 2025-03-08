using Drawing_App_v01.Model;
using Drawing_App_v01.Presenter.Commands;
namespace Drawing_App_v01.Presenter.DrawingStates
{
    /// <summary>
    /// Implements IDrawingState to handle drawing points.
    /// Creates and executes a DrawNodeCommand on each mouse click.
    /// </summary>
    public class NodeDrawingState : IDrawingState
    {
        protected readonly DrawingSettings _drawingSettings;

        public NodeDrawingState(DrawingSettings drawingSettings)
        {
            _drawingSettings = drawingSettings;
        }

        public void HandleMouseDown(MainWindowPresenter presenter, DrawingModel model, int x, int y)
        {
            IDrawingCommand drawCommand = new DrawNodeCommand(_drawingSettings.DrawingColor, _drawingSettings.DrawingNodeSize);
            drawCommand.Execute(model, x, y);
            presenter.View.InvalidateCanvas();
        }
    }
}
