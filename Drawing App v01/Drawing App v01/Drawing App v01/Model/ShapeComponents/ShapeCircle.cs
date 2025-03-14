using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Drawing_App_v01.Model.ShapeComponents
{
    internal class ShapeCircle : ShapeBase
    {
        public Node CenterPoint { get; set; }
        public Node RadiusPoint { get; set; }
        public int Radius { get; set; }


        public ShapeCircle(Color shapeColor, Node centerPoint, Node radiusPoint, int lineWeight)
        {
            CenterPoint = centerPoint;
            RadiusPoint = radiusPoint;
            RadiusSetter();
            ShapeLineWeight = lineWeight;
            ShapeColor = shapeColor;
            ShapeName = "Circle";
        }

        [JsonConstructor]
        public ShapeCircle() { }

        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(ShapeColor, ShapeLineWeight))
            {
                g.DrawEllipse(pen, CenterPoint.X - Radius, CenterPoint.Y - Radius, Radius * 2, Radius * 2);
            }
        }

        private void RadiusSetter()
        {
            Radius = (int)Math.Sqrt(Math.Pow(RadiusPoint.X - CenterPoint.X, 2) + Math.Pow(RadiusPoint.Y - CenterPoint.Y, 2));
        }

        public override bool IsNear(Point p, int threshold)
        {
            double distance = Math.Sqrt(Math.Pow(p.X - CenterPoint.X, 2) + Math.Pow(p.Y - CenterPoint.Y, 2));
            return Math.Abs(distance - Radius) <= threshold;
        }
    }
}
