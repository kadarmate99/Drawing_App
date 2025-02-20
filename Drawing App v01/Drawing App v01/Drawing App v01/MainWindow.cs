// Description: The primary application window

using System.Windows.Forms;

namespace Drawing_App_v01
{
    public partial class MainWindow : Form
    {
        //-----------------------------------------------------------------------------
        // Fields
        //-----------------------------------------------------------------------------
        private string _clickType;
        private Node _firstNode = null;  // Stores first point for line drawing
        private Node _tempSecondNode = null;  // Temporary node for preview line

        private readonly DrawingManager _drawing;

        //-----------------------------------------------------------------------------
        // Constructor  
        //-----------------------------------------------------------------------------
        public MainWindow(DrawingManager drawing)
        {
            InitializeComponent();
            _drawing = drawing;

            // Enable double buffering for the panel to reduce flickering
            canvasPanel.GetType().GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic)
                .SetValue(canvasPanel, true, null);
        }

        //-----------------------------------------------------------------------------
        // Event Handlers
        //-----------------------------------------------------------------------------
        private void CanvasPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            _drawing.Render(e.Graphics);

            // Draw temporary line when defining a new line
            if (_clickType == "line" && _firstNode != null && _tempSecondNode != null)
            {
                e.Graphics.DrawLine(Pens.Black, _firstNode.X, _firstNode.Y, _tempSecondNode.X, _tempSecondNode.Y);
            }
        }

        // Handles mouse clicks for drawing points and lines
        private void CanvasPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Node tempNode = new Node(e.X, e.Y);

            if (_clickType == "point")
            {
                _drawing.AddNode(tempNode);
            }
            else if (_clickType == "line")
            {
                if (_firstNode == null)
                {
                    _firstNode = tempNode;
                    _drawing.AddNode(tempNode);
                }
                else
                {
                    Node secondNode = tempNode;
                    _drawing.AddNode(secondNode);
                    _drawing.AddLine(new Line(_firstNode, secondNode));

                    // Reset for next line
                    _firstNode = null;
                    _tempSecondNode = null;
                }
            }

            // Request repaint
            canvasPanel.Invalidate();
        }

        // Handles mouse movement for previewing the temporary line
        private void CanvasPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_clickType == "line" && _firstNode != null)
            {
                _tempSecondNode = new Node(e.X, e.Y);
                canvasPanel.Invalidate();
            }
        }

        private void BtnPoint_Click(object sender, EventArgs e)
        {
            _clickType = "point";
        }

        private void BtnLine_Click(object sender, EventArgs e)
        {
            _clickType = "line";
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = FileHandler.OpenFileDialog();
            if (!string.IsNullOrEmpty(filePath))
            {
                _drawing.LoadDrawingFile(filePath);
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
            _drawing.LoadDrawingFile(filePath);
            canvasPanel.Invalidate();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            _drawing.ClearCanvas();
            canvasPanel.Invalidate();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


    }
}
