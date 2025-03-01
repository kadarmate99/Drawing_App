using Drawing_App_v01.Model.ShapeComponents;
using Drawing_App_v01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing_App_v01.Presenter.Commands
{
    internal class DrawRhombusCommand : IDrawingCommand
    {
        private Node _startPoint;

        public DrawRhombusCommand(Node startPoint)
        {
            _startPoint = startPoint;
        }

        public void Execute(DrawingModel model, int x, int y)
        {
            if (_startPoint != null)
            {
                ShapeRhombus rhombus = new ShapeRhombus(_startPoint, new Node(x, y));
                model.AddShape(rhombus);
            }
        }
    }
}
