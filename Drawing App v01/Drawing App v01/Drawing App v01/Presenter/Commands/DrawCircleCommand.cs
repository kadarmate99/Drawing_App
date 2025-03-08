using Drawing_App_v01.Model.ShapeComponents;
using Drawing_App_v01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing_App_v01.Presenter.Commands
{
    public class DrawCircleCommand : IDrawingCommand
    {
        private Node _startPoint;
        private Color _currentColor;
        private int _currentLineWidth;

        public DrawCircleCommand(Color currentColor, Node startPoint, int currentLineWidth)
        {
            _startPoint = startPoint;
            _currentColor = currentColor;
            _currentLineWidth = currentLineWidth;
        }

        public void Execute(DrawingModel model, int x, int y)
        {
            if (_startPoint != null)
            {
                ShapeCircle circle = new ShapeCircle(_currentColor, _startPoint, new Node(_currentColor, x, y), _currentLineWidth);
                model.AddShape(circle);
            }
        }
    }
}
