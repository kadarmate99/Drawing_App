using Newtonsoft.Json;
using System.Drawing;
using static System.Windows.Forms.AxHost;

namespace Drawing_App_v01.Model.ShapeComponents
{
    public abstract class ShapeBase
    {
        public Color ShapeColor { get; set; }
        public int ShapeLineWeight { get; set; }
        public string ShapeName { get; set; }

        public abstract void Draw(Graphics g);

        /// <summary>
        /// Checks if a point is near the shape.
        /// </summary>
        public abstract bool IsNear(Point p, int threshold);

        /// <summary>
        /// Calculates the perpendicular (shortest) distance from a given "P" point to a "AB" line segment.
        /// </summary>
        protected double DistanceToLine(Node A, Node B, Point P)
        {
            // Compute the absolute value of the determinant formula
            double numerator = Math.Abs((B.Y - A.Y) * P.X - (B.X - A.X) * P.Y + B.X * A.Y - B.Y * A.X);

            // Denominator is the Euclidean distance between points A and B (length of the line segment)
            double denominator = Math.Sqrt(Math.Pow(B.Y - A.Y, 2) + Math.Pow(B.X - A.X, 2));

            // Avoid division by zero (if A and B are the same point, the line segment is a single point returne a big distance)
            if (denominator == 0) return double.MaxValue;

            return numerator / denominator; // Returns perpendicular distance
        }

    }
}
