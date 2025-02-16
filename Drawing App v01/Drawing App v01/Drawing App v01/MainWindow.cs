namespace Drawing_App_v01
{
    public partial class frmMainWindow : Form
    {

        private readonly Drawing _drawing = new Drawing();

        public frmMainWindow()
        {
            InitializeComponent();
        }

        public void OnFileSelectedToLoad(object sender, string filePath)
        {
            _drawing.LoadFromFile(filePath);
            canvasPanel.Invalidate();
        }
          
        private void CanvasPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            _drawing.ClearCanvas();
            canvasPanel.Invalidate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _drawing.SaveAs(saveFileDialog.FileName);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _drawing.LoadFromFile(openFileDialog.FileName);
                canvasPanel.Invalidate();
            }
        }
    }
}
