using Drawing_App_v01.Model;

/// <summary>
/// Defines the interface for a drawing state. Drawing states encapsulate
/// the behavior of the drawing canvas in different modes (e.g., drawing points,
/// lines, rectangles). Allows MainWindowPresenter to delegate mouse event 
/// handling to the active drawing mode.
/// </summary>
namespace Drawing_App_v01.Presenter.DrawingStates
{
    public interface IDrawingState
    {
        void HandleMouseDown(MainWindowPresenter presenter, DrawingModel model, int x, int y);
    }
}
