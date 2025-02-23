using Newtonsoft.Json;

namespace Drawing_App_v01.Model.ShapeComponents
{
    /// <summary>
    /// Represents a line shape.
    /// </summary>
    public class ShapeLine : Shape
    {
        public Node StartingPoint { get; set; }
        public Node EndingPoint { get; set; }

        public ShapeLine(Node startingPoint, Node endingPoint, int lineWeight = 1, Color? color = null)
        {
            StartingPoint = startingPoint;
            EndingPoint = endingPoint;
            ShapeLineWeight = lineWeight;
            ShapeColor = color ?? Color.Black; // Default to Black if no color is provided
        }

        [JsonConstructor]
        public ShapeLine() { }

        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color.Black, ShapeLineWeight))
            {
                g.DrawLine(pen, StartingPoint.X, StartingPoint.Y, EndingPoint.X, EndingPoint.Y);
            }
        }

    }
}
