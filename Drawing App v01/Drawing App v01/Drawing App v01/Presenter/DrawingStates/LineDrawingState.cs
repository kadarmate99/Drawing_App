using Drawing_App_v01.Model;
using Drawing_App_v01.Model.ShapeComponents;
using Drawing_App_v01.Presenter.Commands;

namespace Drawing_App_v01.Presenter.DrawingStates

{
    /// <summary>
    /// Implements IDrawingState to handle drawing lines.
    /// Uses DrawLineCommand to draw a line.
    /// </summary>
    public class LineDrawingState : ShapeDrawingStateBase
    {
        public LineDrawingState(Color currentColor, int currentLineWidth) : base(currentColor, currentLineWidth) {}

        public override void HandleMouseDown(MainWindowPresenter presenter, DrawingModel model, int x, int y)
        {
            if (!_isDrawing)
            {
                _startPoint = new Node(_currentColor,x, y);
                _isDrawing = true;
            }
            else
            {
                IDrawingCommand drawCommand = new DrawLineCommand(_currentColor, _startPoint, _currentLineWidth);
                drawCommand.Execute(model, x, y);
                presenter.View.InvalidateCanvas();
                _isDrawing=false;
            }
        }

        public override void TemporaryDraw(Graphics g)
        {
            if (_isDrawing && _startPoint != null && _currentPoint != null)
            {
                ShapeLine line = new ShapeLine(_currentColor, _startPoint, _currentPoint, _currentLineWidth);
                line.Draw(g);
            }
        }
    }
}
