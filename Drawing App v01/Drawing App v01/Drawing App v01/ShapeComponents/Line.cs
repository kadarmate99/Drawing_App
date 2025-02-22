using Newtonsoft.Json;

namespace Drawing_App_v01.ShapeComponents
{
    /// <summary>
    /// Represents a line shape.
    /// </summary>
    public class Line : Shape
    {
        [JsonProperty]
        public Node StartingPoint { get; set; }
        [JsonProperty]
        public Node EndingPoint { get; set; }

        public Line(Node startingPoint, Node endingPoint, int lineWeight = 1)
        {
            StartingPoint = startingPoint;
            EndingPoint = endingPoint;
            ShapeLineWeight = lineWeight;
        }

        [JsonConstructor]
        public Line() { }

        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color.Black, ShapeLineWeight))
            {
                g.DrawLine(pen, StartingPoint.X, StartingPoint.Y, EndingPoint.X, EndingPoint.Y);
            }
        }

    }
}
