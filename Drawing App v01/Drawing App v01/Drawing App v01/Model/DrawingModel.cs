// Description: Centralized class for managing all drawing-related data

using System.IO;
using Drawing_App_v01.Model.ShapeComponents;

namespace Drawing_App_v01.Model
{
    public class DrawingModel
    {
        public List<ShapeBase> Shapes { get; private set; }
        public string FilePath { get; private set; }
        public float ZoomLevel { get; private set; } = 1.0f;
        public PointF ViewOffset { get; private set; } = new PointF(0, 0);

        public DrawingModel()
        {
            Shapes = new List<ShapeBase>();
        }
        public void RenderModel(Graphics g)
        {
            foreach (ShapeBase shape in Shapes)
            {
                shape.Draw(g);
            }
        }

        public void RenderShape(Graphics g, ShapeBase shape)
        {
            shape.Draw(g);
        }

        public void SetFilePath(string filePath)
        {
            FilePath = filePath;
        }

        public void AddShape(ShapeBase shape)
        {
            Shapes.Add(shape);
        }

        public void RemoveShape(ShapeBase shape)
        {
            Shapes.Remove(shape);
        }

        public void ClearShapes()
        {
            Shapes.Clear();
        }

        public void SetView(float zoomLevel, PointF viewOffset)
        {
            ViewOffset = viewOffset;
            ZoomLevel = zoomLevel;
        }
    }
}
