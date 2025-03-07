using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing_App_v01.Model.ShapeComponents
{
    internal class ShapeRectangle : ShapeBase
    {
        /// <summary>
        /// Upper left corner point of rectangle
        /// </summary>
        public Node CornerPoint_01 { get; set; }
        /// <summary>
        /// Upper right corner point of rectangle
        /// </summary>
        public Node CornerPoint_02 { get; set; }
        /// <summary>
        /// Lower right point of rectangle
        /// </summary>
        public Node CornerPoint_03 { get; set; }
        /// <summary>
        /// Lower left corner point of rectangle
        /// </summary>
        public Node CornerPoint_04 { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public ShapeRectangle(Color shapeColor, Node point_01, Node point_02, int lineWeight = 1)
        {
            CornerPoint_01 = new Node();
            CornerPoint_02 = new Node();
            CornerPoint_03 = new Node();
            CornerPoint_04 = new Node();
            RectanglePropertySetter(point_01, point_02);
            ShapeLineWeight = lineWeight;
            ShapeColor = shapeColor;
        }

        [JsonConstructor]
        public ShapeRectangle() { }

        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(ShapeColor, ShapeLineWeight))
            {
                g.DrawRectangle(pen, CornerPoint_01.X, CornerPoint_01.Y, Width, Height );
            }
        }

        private void RectanglePropertySetter(Node point_01, Node point_02)
        {
            int diffX = point_01.X - point_02.X;
            int diffY = point_01.Y - point_02.Y;

            if (diffX < 0 && diffY < 0)
            {
                CornerPoint_01 = point_01;
            }
            else if (diffX > 0 && diffY > 0)
            {
                CornerPoint_01 = point_02;
            }
            else if (diffX < 0 && diffY > 0)
            {
                CornerPoint_01.X = point_01.X;
                CornerPoint_01.Y = point_02.Y;
            }
            else if (diffX > 0 && diffY <0)
            {
                CornerPoint_01.X = point_02.X;
                CornerPoint_01.Y = point_01.Y;
            }

            Width = Math.Abs(diffX);
            Height = Math.Abs(diffY);

            CornerPoint_02.X = CornerPoint_01.X + Width;
            CornerPoint_02.Y = CornerPoint_01.Y;

            CornerPoint_03.X = CornerPoint_01.X + Width;
            CornerPoint_03.Y = CornerPoint_01.Y + Height;

            CornerPoint_04.X = CornerPoint_01.X;
            CornerPoint_04.Y = CornerPoint_01.Y + Height;
        }
    }
}
