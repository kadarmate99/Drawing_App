using Newtonsoft.Json;

namespace Drawing_App_v01.Model.ShapeComponents
{
    /// <summary>
    /// Represents a line shape.
    /// </summary>
    public class ShapeLine : ShapeBase
    {
        public Node StartingPoint { get; set; }
        public Node EndingPoint { get; set; }

        public ShapeLine(Color shapeColor, Node startingPoint, Node endingPoint, int shapeLineWidth)
        {
            ShapeColor = shapeColor;
            StartingPoint = startingPoint;
            EndingPoint = endingPoint;
            ShapeLineWeight = shapeLineWidth;
            ShapeName = "Line";
        }

        [JsonConstructor]
        public ShapeLine() { }

        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(ShapeColor, ShapeLineWeight))
            {
                g.DrawLine(pen, StartingPoint.X, StartingPoint.Y, EndingPoint.X, EndingPoint.Y);
            }
        }

        public override bool IsNear(Point p, int threshold)
        {
            return DistanceToLine(StartingPoint, EndingPoint, p) <= threshold;
        }
    }
}
