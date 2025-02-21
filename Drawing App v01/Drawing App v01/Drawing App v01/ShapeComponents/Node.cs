using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Drawing_App_v01.ShapeComponents
{
    public class Node : Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public Node(int x, int y, int size = 5, Color? color = null)
        {
            X = x;
            Y = y;
            ShapeLineWeight = size;
            ShapeColor = color ?? Color.Black; // Default to Black if no color is provided
        }

        public override void Draw(Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(ShapeColor))
            {
                g.FillRectangle(brush, X - ShapeLineWeight / 2, Y - ShapeLineWeight / 2, ShapeLineWeight, ShapeLineWeight);
            }
        }
    }
}
