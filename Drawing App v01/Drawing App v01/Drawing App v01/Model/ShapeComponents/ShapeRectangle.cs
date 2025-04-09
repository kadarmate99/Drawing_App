using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing_App_v01.Model.ShapeComponents
{
    /// <summary>
    /// Represents a rectangle defined by two corner points.
    /// </summary>
    internal class ShapeRectangle : ShapeBase
    {

        public Node UperLeftCorner { get; set; }
        public Node UperRightCorner { get; set; }
        public Node LowerRightCorner { get; set; }
        public Node LowerLeftCorner { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        

        public ShapeRectangle(Color shapeColor, Node point_01, Node point_02, int lineWeight)
        {
            UperLeftCorner = new Node();
            UperRightCorner = new Node();
            LowerRightCorner = new Node();
            LowerLeftCorner = new Node();
            RectanglePropertySetter(point_01, point_02);
            ShapeLineWeight = lineWeight;
            ShapeColor = shapeColor;
            ShapeName = "Rectangle";
        }

        [JsonConstructor]
        public ShapeRectangle() { }

        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(ShapeColor, ShapeLineWeight))
            {
                g.DrawRectangle(pen, UperLeftCorner.X, UperLeftCorner.Y, Width, Height );
            }
        }

        private void RectanglePropertySetter(Node point_01, Node point_02)
        {
            int diffX = point_01.X - point_02.X;
            int diffY = point_01.Y - point_02.Y;

            if (diffX < 0 && diffY < 0)
            {
                UperLeftCorner = point_01;
            }
            else if (diffX > 0 && diffY > 0)
            {
                UperLeftCorner = point_02;
            }
            else if (diffX < 0 && diffY > 0)
            {
                UperLeftCorner.X = point_01.X;
                UperLeftCorner.Y = point_02.Y;
            }
            else if (diffX > 0 && diffY <0)
            {
                UperLeftCorner.X = point_02.X;
                UperLeftCorner.Y = point_01.Y;
            }

            Width = Math.Abs(diffX);
            Height = Math.Abs(diffY);

            UperRightCorner.X = UperLeftCorner.X + Width;
            UperRightCorner.Y = UperLeftCorner.Y;

            LowerRightCorner.X = UperLeftCorner.X + Width;
            LowerRightCorner.Y = UperLeftCorner.Y + Height;

            LowerLeftCorner.X = UperLeftCorner.X;
            LowerLeftCorner.Y = UperLeftCorner.Y + Height;
        }

        public override bool IsNear(Point p, int threshold)
        {
            return
                DistanceToLine(UperLeftCorner, UperRightCorner, p) <= threshold ||
                DistanceToLine(UperRightCorner, LowerRightCorner, p) <= threshold ||
                DistanceToLine(LowerRightCorner, LowerLeftCorner, p) <= threshold ||
                DistanceToLine(LowerLeftCorner, UperLeftCorner, p) <= threshold;
        }
    }
}
