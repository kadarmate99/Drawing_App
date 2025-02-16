using System.Windows.Forms;

namespace Drawing_App_v01
{
    public partial class MainWindow : Form
    {
        //-----------------------------------------------------------------------------
        // Fields and Constants
        //-----------------------------------------------------------------------------
        private readonly Drawing _drawing = new Drawing();

        //-----------------------------------------------------------------------------
        // Constructor  
        //-----------------------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------
        // Canvas Event Handlers
        //-----------------------------------------------------------------------------
        private void CanvasPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // to bee copied to: _drawing.Render(e.Graphics); 
            foreach (Node node in _drawing.Nodes)
            {
                g.FillRectangle(Brushes.Black, node.X - node.Size / 2, node.Y - node.Size / 2, node.Size, node.Size);
            }
            
        }

        private void CanvasPanel_MouseClick(object sender, MouseEventArgs e)
        {
            _drawing.AddNode(new Node(e.X, e.Y));
            canvasPanel.Invalidate();
        }


        //-----------------------------------------------------------------------------
        // File Event Handlers
        //-----------------------------------------------------------------------------
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = FileHandler.OpenFileDialog();
            if (!string.IsNullOrEmpty(filePath) ) 
            {
                _drawing.LoadFromFile(filePath);
                canvasPanel.Invalidate();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = FileHandler.SaveFileDialog();
            if (!string.IsNullOrEmpty(filePath))
            {
                _drawing.SaveAs(filePath);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Implement Save As functionality
        }

        public void OnFileSelectedToLoad(object sender, string filePath)
        {
            _drawing.LoadFromFile(filePath);
            canvasPanel.Invalidate();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _drawing.ClearCanvas();
            canvasPanel.Invalidate();
        }
    }
}
