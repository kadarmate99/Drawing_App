using System.Drawing;
using System.Text.Json.Serialization;

namespace Drawing_App_v01.Model.ShapeComponents
{
    internal class ShapeRhombus : ShapeBase
    {
        public Node CenterPoint { get; set; }

        /// <summary>
        /// Upper left corner point
        /// </summary>
        public Node CornerPoint_01 { get; set; }

        /// <summary>
        /// Upper right corner point
        /// </summary>
        public Node CornerPoint_02 { get; set; }

        /// <summary>
        /// Lower right point
        /// </summary>
        public Node CornerPoint_03 { get; set; }

        /// <summary>
        /// Lower left corner point
        /// </summary>
        public Node CornerPoint_04 { get; set; }
        /// <summary>
        /// Property to indicate if the rhombus is valid (not a line - corner point is horizontally aligned with the center point)
        /// </summary>
        public bool IsValid { get; private set; } = true;

        public ShapeRhombus(Node centerPoint, Node cornerPoint, int lineWeight = 1, Color? color = null)
        {
            CenterPoint = centerPoint;
            CornerPoint_01 = new Node();
            CornerPoint_02 = new Node();
            CornerPoint_03 = new Node();
            CornerPoint_04 = new Node();
            RhombusPropertySetter(centerPoint, cornerPoint);
            ShapeLineWeight = lineWeight;
            ShapeColor = color ?? Color.Black; // Default to Black if no color is provided
        }

        [JsonConstructor]
        public ShapeRhombus() { }

        public override void Draw(Graphics g)
        {
            if (IsValid)
            {
                using (Pen pen = new Pen(Color.Black, ShapeLineWeight))
                {
                    g.DrawLines(pen, new Point[]
                    {
                    new Point(CornerPoint_01.X, CornerPoint_01.Y),
                    new Point(CornerPoint_02.X, CornerPoint_02.Y),
                    new Point(CornerPoint_03.X, CornerPoint_03.Y),
                    new Point(CornerPoint_04.X, CornerPoint_04.Y),
                    new Point(CornerPoint_01.X, CornerPoint_01.Y)
                    });
                }
            }
        }

        private void RhombusPropertySetter(Node centerPoint, Node cornerPoint)
        {
            int diffX = cornerPoint.X - centerPoint.X;
            int diffY = cornerPoint.Y - centerPoint.Y;

            if (diffX < 0 && diffY < 0)
            {
                CornerPoint_01 = cornerPoint;
                CornerPoint_03.X = CenterPoint.X - diffX;
                CornerPoint_03.Y = CenterPoint.Y - diffY;

                // Check if the points are horizontally aligned
                if (CornerPoint_03.Y == CornerPoint_01.Y)
                {
                    IsValid = false;
                    return; // Exit the method to prevent Divided by Zero Exception
                }

                CornerPoint_02.Y = CornerPoint_01.Y;
                CornerPoint_02.X = (int)((CornerPoint_01.Y - CenterPoint.Y + ((double)(CornerPoint_01.X - CornerPoint_03.X) / (double)(CornerPoint_03.Y - CornerPoint_01.Y)) * CenterPoint.X) / ((double)(CornerPoint_01.X - CornerPoint_03.X) / (double)(CornerPoint_03.Y - CornerPoint_01.Y)));

                int cornerDiffX = CornerPoint_02.X - CornerPoint_01.X;

                CornerPoint_04.Y = CornerPoint_03.Y;
                CornerPoint_04.X = CornerPoint_03.X - cornerDiffX;
            }
            else if (diffX > 0 && diffY > 0)
            {
                CornerPoint_03 = cornerPoint;
                CornerPoint_01.X = CenterPoint.X - diffX;
                CornerPoint_01.Y = CenterPoint.Y - diffY;

                // Check if the points are horizontally aligned
                if (CornerPoint_03.Y == CornerPoint_01.Y)
                {
                    IsValid = false;
                    return; // Exit the method to prevent Divided by Zero Exception
                }

                CornerPoint_02.Y = CornerPoint_01.Y;
                CornerPoint_02.X = (int)((CornerPoint_01.Y - CenterPoint.Y + ((double)(CornerPoint_01.X - CornerPoint_03.X) / (double)(CornerPoint_03.Y - CornerPoint_01.Y)) * CenterPoint.X) / ((double)(CornerPoint_01.X - CornerPoint_03.X) / (double)(CornerPoint_03.Y - CornerPoint_01.Y)));

                int cornerDiffX = CornerPoint_02.X - CornerPoint_01.X;

                CornerPoint_04.Y = CornerPoint_03.Y;
                CornerPoint_04.X = CornerPoint_03.X - cornerDiffX;
            }
            else if (diffX < 0 && diffY > 0)
            {
                CornerPoint_04 = cornerPoint;
                CornerPoint_02.X = CenterPoint.X - diffX;
                CornerPoint_02.Y = CenterPoint.Y - diffY;

                // Check if the points are horizontally aligned
                if (CornerPoint_04.Y == CornerPoint_02.Y)
                {
                    IsValid = false;
                    return; // Exit the method to prevent Divided by Zero Exception
                }

                CornerPoint_01.Y = CornerPoint_02.Y;
                CornerPoint_01.X = (int)((CornerPoint_02.Y - CenterPoint.Y + ((double)(CornerPoint_02.X - CornerPoint_04.X) / (double)(CornerPoint_04.Y - CornerPoint_02.Y)) * CenterPoint.X) / ((double)(CornerPoint_02.X - CornerPoint_04.X) / (double)(CornerPoint_04.Y - CornerPoint_02.Y)));

                int cornerDiffX = CornerPoint_01.X - CornerPoint_02.X;

                CornerPoint_03.Y = CornerPoint_04.Y;
                CornerPoint_03.X = CornerPoint_04.X - cornerDiffX;
            }
            else if (diffX > 0 && diffY < 0)
            {
                CornerPoint_02 = cornerPoint;
                CornerPoint_04.X = CenterPoint.X - diffX;
                CornerPoint_04.Y = CenterPoint.Y - diffY;

                // Check if the points are horizontally aligned
                if (CornerPoint_04.Y == CornerPoint_02.Y)
                {
                    IsValid = false;
                    return; // Exit the method to prevent Divided by Zero Exception
                }

                CornerPoint_01.Y = CornerPoint_02.Y;
                CornerPoint_01.X = (int)((CornerPoint_02.Y - CenterPoint.Y + ((double)(CornerPoint_02.X - CornerPoint_04.X) / (double)(CornerPoint_04.Y - CornerPoint_02.Y)) * CenterPoint.X) / ((double)(CornerPoint_02.X - CornerPoint_04.X) / (double)(CornerPoint_04.Y - CornerPoint_02.Y)));

                int cornerDiffX = CornerPoint_01.X - CornerPoint_02.X;

                CornerPoint_03.Y = CornerPoint_04.Y;
                CornerPoint_03.X = CornerPoint_04.X - cornerDiffX;
            }
        }
    }
}
