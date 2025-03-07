using Newtonsoft.Json;

namespace Drawing_App_v01.Model.ShapeComponents
{
    public class Node : ShapeBase
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Node(Color shapeColor, int x, int y, int size = 5)
        {
            X = x;
            Y = y;
            ShapeLineWeight = size;
            ShapeColor = shapeColor;
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
