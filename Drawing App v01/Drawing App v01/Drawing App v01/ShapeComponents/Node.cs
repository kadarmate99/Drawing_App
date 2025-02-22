using Newtonsoft.Json;

namespace Drawing_App_v01.ShapeComponents
{
    public class Node : Shape
    {
        [JsonProperty]
        public int X { get; set; }
        [JsonProperty]
        public int Y { get; set; }
        
        public Node(int x, int y, int size = 5, Color? color = null)
        {
            X = x;
            Y = y;
            ShapeLineWeight = size;
            ShapeColor = color ?? Color.Black; // Default to Black if no color is provided
        }

        [JsonConstructor]
        public Node() { }

        public override void Draw(Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(ShapeColor))
            {
                g.FillRectangle(brush, X - ShapeLineWeight / 2, Y - ShapeLineWeight / 2, ShapeLineWeight, ShapeLineWeight);
            }
        }
    }
}
