// Description: The primary application window

using System.Windows.Forms;
using Drawing_App_v01.Presenter;

namespace Drawing_App_v01
{
    public partial class MainWindow : Form
    {
        //-----------------------------------------------------------------------------
        // Fields
        //-----------------------------------------------------------------------------
        private readonly MainWindowPresenter _presenter;

        public Panel CanvasPanel // Expose the CanvasPanel
        {
            get { return canvasPanel; }
        }

        //-----------------------------------------------------------------------------
        // Constructor  
        //-----------------------------------------------------------------------------
        public MainWindow(MainWindowPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;
            _presenter.SetView(this); // Give the presenter a reference to the view

            // Enable double buffering for the panel to reduce flickering
            canvasPanel.GetType().GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic)
                .SetValue(canvasPanel, true, null);
        }

        //-----------------------------------------------------------------------------
        // Event Handlers
        //-----------------------------------------------------------------------------

        //- - - - -  CanvasPanel related events  - - - - -
        private void CanvasPanel_Paint(object sender, PaintEventArgs e)
        {
            _presenter.OnCanvasPanel_Paint(e);
        }
        private void CanvasPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _presenter.OnCanvasPanel_MouseDown(e);
        }
        private void CanvasPanel_MouseMove(object sender, MouseEventArgs e)
        {
            _presenter.OnCanvasPanel_MouseMove(e);
        }

        //- - - - -  Button click related events  - - - - -
        private void BtnPoint_Click(object sender, EventArgs e)
        {
            _presenter.OnBtnPoint_Click();
        }
        private void BtnLine_Click(object sender, EventArgs e)
        {
            _presenter.OnBtnLine_Click();
        }
        private void BtnRectangle_Click(object sender, EventArgs e)
        {
            _presenter.OnBtnRectangle_Click();
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            _presenter.OnBtnClear_Click();
        }

        //- - - - -  Strip Menu click related events  - - - - -
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.OnOpenToolStripMenuItem_Click();
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.OnSaveToolStripMenuItem_Click();

        }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.OnSaveAsToolStripMenuItem_Click();
        }

        //-----------------------------------------------------------------------------
        // Methods
        //-----------------------------------------------------------------------------
        public void InvalidateCanvas()
        {
            canvasPanel.Invalidate();
        }

        
    }
}
