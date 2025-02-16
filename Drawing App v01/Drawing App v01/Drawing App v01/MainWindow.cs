using System.Windows.Forms;

namespace Drawing_App_v01
{
    public partial class MainWindow : Form
    {
        //-----------------------------------------------------------------------------
        // Fields and Constants
        //-----------------------------------------------------------------------------
        private readonly Drawing _drawing;

        //-----------------------------------------------------------------------------
        // Constructor  
        //-----------------------------------------------------------------------------
        public MainWindow(Drawing drawing)
        {
            InitializeComponent();
            _drawing = drawing;            
        }

        //-----------------------------------------------------------------------------
        // Canvas Event Handlers
        //-----------------------------------------------------------------------------
        private void CanvasPanel_Paint(object sender, PaintEventArgs e)
        {
            _drawing.Render(e.Graphics);         
        }

        private void CanvasPanel_MouseClick(object sender, MouseEventArgs e)
        {
            _drawing.AddNode(new Node(e.X, e.Y));
            canvasPanel.Invalidate();
        }


        //-----------------------------------------------------------------------------
        // File Event Handlers
        //-----------------------------------------------------------------------------
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = FileHandler.OpenFileDialog();
            if (!string.IsNullOrEmpty(filePath) ) 
            {
                _drawing.LoadFromFile(filePath);
                canvasPanel.Invalidate();
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = FileHandler.SaveFileDialog();
            if (!string.IsNullOrEmpty(filePath))
            {
                _drawing.SaveAs(filePath);
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Implement Save As functionality
        }

        public void OnFileSelectedToLoad(object sender, string filePath)
        {
            _drawing.LoadFromFile(filePath);
            canvasPanel.Invalidate();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            _drawing.ClearCanvas();
            canvasPanel.Invalidate();
        }
    }
}
