using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing_App_v01
{
    public class Line
    {
        public Node StartingPoint { get; set; }
        public Node EndingPoint { get; set; }
        public int LineWeight { get; set; }

        public Line(Node startingPoint, Node endingPoint, int lineWeight = 1)
        {
            StartingPoint = startingPoint;
            EndingPoint = endingPoint;
            LineWeight = lineWeight;
        }

    }
}
