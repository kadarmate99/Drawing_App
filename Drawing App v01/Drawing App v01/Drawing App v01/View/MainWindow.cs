// Description: The primary application window

using System.Windows.Forms;
using Drawing_App_v01.Model.ShapeComponents;
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

        public Panel ColorPanel
        {
            get { return colorPanel; }
        }

        //-----------------------------------------------------------------------------
        // Constructor  
        //-----------------------------------------------------------------------------
        public MainWindow(MainWindowPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;
            _presenter.SetView(this); // Give the presenter a reference to the view
            CmbLineWidth.SelectedIndex = 0;
            CmbNodeSize.SelectedIndex = 4;

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
        private void BtnCircle_Click(object sender, EventArgs e)
        {
            _presenter.OnBtnCircle_Click();
        }
        private void BtnRhombus_Click(object sender, EventArgs e)
        {
            _presenter.BtnRhombus_Click();
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            _presenter.OnBtnClear_Click();
        }
        //- - - - -  Drawing object property setters (color, line width)  - - - - -
        private void ColorPanel_DoubleClick(object sender, EventArgs e)
        {
            _presenter.ColorPanel_DoubleClick();
        }
        private void CmbLineWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = CmbLineWidth.SelectedIndex;
            _presenter.OnCmbLineWidth_SelectedIndexChanged(index);
        }
        private void CmbNodeSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = CmbNodeSize.SelectedIndex;
            _presenter.OnCmbNodeSize_SelectedIndexChanged(index);
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
