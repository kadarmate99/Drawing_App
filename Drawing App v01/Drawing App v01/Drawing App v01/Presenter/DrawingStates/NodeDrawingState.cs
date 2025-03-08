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
        private readonly Color _currentColor;
        private readonly int _currentNodeSize;

        public NodeDrawingState(Color currentColor, int currentNodeSize)
        {
            _currentColor = currentColor;
            _currentNodeSize = currentNodeSize;
        }

        public void HandleMouseDown(MainWindowPresenter presenter, DrawingModel model, int x, int y)
        {
            IDrawingCommand drawCommand = new DrawNodeCommand(_currentColor, _currentNodeSize);
            drawCommand.Execute(model, x, y);
            presenter.View.InvalidateCanvas();
        }
    }
}
