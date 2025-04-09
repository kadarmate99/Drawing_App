using Drawing_App_v01.Model;


namespace Drawing_App_v01.Presenter.DrawingStates
{
    /// <summary>
    /// Defines the interface for drawing states. Implements the state pattern
    /// for managing different drawing modes.
    /// </summary>
    public interface IDrawingState
    {
        /// <summary>
        /// Handles mouse down events in the current drawing state.
        /// </summary>
        /// <param name="presenter">The presenter controlling the drawing.</param>
        /// <param name="model">The drawing model to modify.</param>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        void HandleMouseDown(MainWindowPresenter presenter, DrawingModel model, int x, int y);
    }
}
