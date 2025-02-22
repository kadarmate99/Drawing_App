using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drawing_App_v01.ShapeComponents;

namespace Drawing_App_v01
{
    public class MainWindowPresenter
    {
        //-----------------------------------------------------------------------------
        // Fields
        //-----------------------------------------------------------------------------
        private readonly DrawingManager _drawingManager;
        private string _clickType;
        private Node? _firstNode = null;  // Stores first point for line drawing
        private Node? _tempSecondNode = null;  // Temporary node for preview line
        private MainWindow _view;

        //-----------------------------------------------------------------------------
        // Constructor  
        //-----------------------------------------------------------------------------
        public MainWindowPresenter(DrawingManager drawingManager)
        {
            _drawingManager = drawingManager;
        }

        public void SetView(MainWindow view)
        {
            _view = view;
        }

        internal void OnCanvasPanel_Paint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            _drawingManager.Render(e.Graphics);

            // Draw temporary line when defining a new line
            if (_clickType == "line" && _firstNode != null && _tempSecondNode != null)
            {
                e.Graphics.DrawLine(Pens.Black, _firstNode.X, _firstNode.Y, _tempSecondNode.X, _tempSecondNode.Y);
            }
        }

        internal void OnCanvasPanel_MouseDown(MouseEventArgs e)
        {

            Node tempNode = new Node(e.X, e.Y);

            if (_clickType == "point")
            {
                _drawingManager.AddShape(tempNode);
            }
            else if (_clickType == "line")
            {
                if (_firstNode == null)
                {
                    _firstNode = tempNode;
                    _drawingManager.AddShape(tempNode);
                }
                else
                {
                    Node secondNode = tempNode;
                    _drawingManager.AddShape(secondNode);
                    _drawingManager.AddShape(new Line(_firstNode, secondNode));

                    // Reset for next line
                    _firstNode = null;
                    _tempSecondNode = null;
                }
            }

            _view.InvalidateCanvas();
        }

        internal void OnCanvasPanel_MouseMove(MouseEventArgs e)
        {
            if (_clickType == "line" && _firstNode != null)
            {
                _tempSecondNode = new Node(e.X, e.Y);
                _view.InvalidateCanvas();
            }
        }

        internal void OnBtnPoint_Click()
        {
            _clickType = "point";
        }

        internal void OnBtnLine_Click()
        {
            _clickType = "line";
        }

        internal void OnBtnClear_Click()
        {
            _drawingManager.ClearCanvas();
            _view.InvalidateCanvas();
        }

        internal void OnOpenToolStripMenuItem_Click()
        {
            string filePath = FileHandler.OpenFileDialog();
            if (!string.IsNullOrEmpty(filePath))
            {
                _drawingManager.LoadDrawingFile(filePath);
                _view.InvalidateCanvas();
            }
        }

        internal void OnSaveToolStripMenuItem_Click()
        {
            string filePath = FileHandler.SaveFileDialog();
            if (!string.IsNullOrEmpty(filePath))
            {
                _drawingManager.SaveAs(filePath);
            }
        }

        internal void OnSaveAsToolStripMenuItem_Click()
        {
            // TODO: Implement Save As functionality
            throw new NotImplementedException();
        }

        public void OnFileSelectedToLoad(object sender, string filePath)
        {
            _drawingManager.LoadDrawingFile(filePath);
            _view.InvalidateCanvas();
        }
    }
}
