using System.Drawing;
using System.Text.Json.Serialization;

namespace Drawing_App_v01.Model.ShapeComponents
{
    /// <summary>
    /// Represents a rhombus (diamond) shape defined by a center point and one corner.
    /// </summary>
    internal class ShapeRhombus : ShapeBase
    {
        public Node CenterPoint { get; set; }
        public Node UperLeftCorner { get; set; }
        public Node UperRightCorner { get; set; }
        public Node LowerRightCorner { get; set; }
        public Node LowerLeftCorner { get; set; }
        /// <summary>
        /// Property to indicate if the rhombus is valid (not a line - corner point is horizontally aligned with the center point)
        /// </summary>
        public bool IsValid { get; private set; } = true;

        public ShapeRhombus(Color shapeColor, Node centerPoint, Node cornerPoint, int lineWeight)
        {
            CenterPoint = centerPoint;
            UperLeftCorner = new Node();
            UperRightCorner = new Node();
            LowerRightCorner = new Node();
            LowerLeftCorner = new Node();
            RhombusPropertySetter(centerPoint, cornerPoint);
            ShapeLineWeight = lineWeight;
            ShapeColor = shapeColor;
            ShapeName = "Rhombus";
        }

        [JsonConstructor]
        public ShapeRhombus() { }

        public override void Draw(Graphics g)
        {
            if (IsValid)
            {
                using (Pen pen = new Pen(ShapeColor, ShapeLineWeight))
                {
                    g.DrawLines(pen, new Point[]
                    {
                    new Point(UperLeftCorner.X, UperLeftCorner.Y),
                    new Point(UperRightCorner.X, UperRightCorner.Y),
                    new Point(LowerRightCorner.X, LowerRightCorner.Y),
                    new Point(LowerLeftCorner.X, LowerLeftCorner.Y),
                    new Point(UperLeftCorner.X, UperLeftCorner.Y)
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
                UperLeftCorner = cornerPoint;
                LowerRightCorner.X = CenterPoint.X - diffX;
                LowerRightCorner.Y = CenterPoint.Y - diffY;

                // Check if the points are horizontally aligned
                if (LowerRightCorner.Y == UperLeftCorner.Y)
                {
                    IsValid = false;
                    return; // Exit the method to prevent Divided by Zero Exception
                }

                UperRightCorner.Y = UperLeftCorner.Y;
                UperRightCorner.X = (int)((UperLeftCorner.Y - CenterPoint.Y + ((double)(UperLeftCorner.X - LowerRightCorner.X) / (double)(LowerRightCorner.Y - UperLeftCorner.Y)) * CenterPoint.X) / ((double)(UperLeftCorner.X - LowerRightCorner.X) / (double)(LowerRightCorner.Y - UperLeftCorner.Y)));

                int cornerDiffX = UperRightCorner.X - UperLeftCorner.X;

                LowerLeftCorner.Y = LowerRightCorner.Y;
                LowerLeftCorner.X = LowerRightCorner.X - cornerDiffX;
            }
            else if (diffX > 0 && diffY > 0)
            {
                LowerRightCorner = cornerPoint;
                UperLeftCorner.X = CenterPoint.X - diffX;
                UperLeftCorner.Y = CenterPoint.Y - diffY;

                // Check if the points are horizontally aligned
                if (LowerRightCorner.Y == UperLeftCorner.Y)
                {
                    IsValid = false;
                    return; // Exit the method to prevent Divided by Zero Exception
                }

                UperRightCorner.Y = UperLeftCorner.Y;
                UperRightCorner.X = (int)((UperLeftCorner.Y - CenterPoint.Y + ((double)(UperLeftCorner.X - LowerRightCorner.X) / (double)(LowerRightCorner.Y - UperLeftCorner.Y)) * CenterPoint.X) / ((double)(UperLeftCorner.X - LowerRightCorner.X) / (double)(LowerRightCorner.Y - UperLeftCorner.Y)));

                int cornerDiffX = UperRightCorner.X - UperLeftCorner.X;

                LowerLeftCorner.Y = LowerRightCorner.Y;
                LowerLeftCorner.X = LowerRightCorner.X - cornerDiffX;
            }
            else if (diffX < 0 && diffY > 0)
            {
                LowerLeftCorner = cornerPoint;
                UperRightCorner.X = CenterPoint.X - diffX;
                UperRightCorner.Y = CenterPoint.Y - diffY;

                // Check if the points are horizontally aligned
                if (LowerLeftCorner.Y == UperRightCorner.Y)
                {
                    IsValid = false;
                    return; // Exit the method to prevent Divided by Zero Exception
                }

                UperLeftCorner.Y = UperRightCorner.Y;
                UperLeftCorner.X = (int)((UperRightCorner.Y - CenterPoint.Y + ((double)(UperRightCorner.X - LowerLeftCorner.X) / (double)(LowerLeftCorner.Y - UperRightCorner.Y)) * CenterPoint.X) / ((double)(UperRightCorner.X - LowerLeftCorner.X) / (double)(LowerLeftCorner.Y - UperRightCorner.Y)));

                int cornerDiffX = UperLeftCorner.X - UperRightCorner.X;

                LowerRightCorner.Y = LowerLeftCorner.Y;
                LowerRightCorner.X = LowerLeftCorner.X - cornerDiffX;
            }
            else if (diffX > 0 && diffY < 0)
            {
                UperRightCorner = cornerPoint;
                LowerLeftCorner.X = CenterPoint.X - diffX;
                LowerLeftCorner.Y = CenterPoint.Y - diffY;

                // Check if the points are horizontally aligned
                if (LowerLeftCorner.Y == UperRightCorner.Y)
                {
                    IsValid = false;
                    return; // Exit the method to prevent Divided by Zero Exception
                }

                UperLeftCorner.Y = UperRightCorner.Y;
                UperLeftCorner.X = (int)((UperRightCorner.Y - CenterPoint.Y + ((double)(UperRightCorner.X - LowerLeftCorner.X) / (double)(LowerLeftCorner.Y - UperRightCorner.Y)) * CenterPoint.X) / ((double)(UperRightCorner.X - LowerLeftCorner.X) / (double)(LowerLeftCorner.Y - UperRightCorner.Y)));

                int cornerDiffX = UperLeftCorner.X - UperRightCorner.X;

                LowerRightCorner.Y = LowerLeftCorner.Y;
                LowerRightCorner.X = LowerLeftCorner.X - cornerDiffX;
            }
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
