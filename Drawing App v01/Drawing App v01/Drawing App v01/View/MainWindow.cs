// Description: The primary application window

using System.Windows.Forms;
using Drawing_App_v01.Model.ShapeComponents;
using Drawing_App_v01.Presenter;
using Drawing_App_v01.View;

namespace Drawing_App_v01
{
    public partial class MainWindow : Form
    {
        //-----------------------------------------------------------------------------
        // Fields
        //-----------------------------------------------------------------------------
        private readonly MainWindowPresenter _presenter;
        private readonly CanvasPanel _canvasPanel;

        public CanvasPanel Canvas => _canvasPanel;
        public Panel ColorPanel => colorPanel;

        //-----------------------------------------------------------------------------
        // Constructor  
        //-----------------------------------------------------------------------------
        public MainWindow(MainWindowPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;
            _presenter.SetView(this); // Give the presenter a reference to the view

            _canvasPanel = new CanvasPanel()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(10, 27),
                Name = "_oldCanvasPanel",
                Size = new Size(813, 413),
                TabIndex = 0,
            };
            Controls.Add(_canvasPanel);
            _canvasPanel.Paint += CanvasPanel_Paint;
            _canvasPanel.MouseDown += CanvasPanel_MouseDown;
            _canvasPanel.MouseMove += CanvasPanel_MouseMove;

            CmbLineWidth.SelectedIndex = 0;
            CmbNodeSize.SelectedIndex = 4;
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
            _canvasPanel.Invalidate();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
