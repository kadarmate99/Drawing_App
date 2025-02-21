using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing_App_v01.ShapeComponents
{
    public class Line : Shape
    {
        public Node StartingPoint { get; set; }
        public Node EndingPoint { get; set; }

        public Line(Node startingPoint, Node endingPoint, int lineWeight = 1)
        {
            StartingPoint = startingPoint;
            EndingPoint = endingPoint;
            ShapeLineWeight = lineWeight;
        }

        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color.Black, ShapeLineWeight))
            {
                g.DrawLine(pen, StartingPoint.X, StartingPoint.Y, EndingPoint.X, EndingPoint.Y);
            }
        }

    }
}
