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
        public UserData UserData { get; set; }

        public DrawingModel()
        {
            Shapes = new List<ShapeBase>();
            UserData = new UserData();
        }
        public void RenderModel(Graphics g)
        {
            foreach (ShapeBase shape in Shapes)
            {
                shape.Draw(g);
            }
        }

        public void SetFilePath(string filePath)
        {
            FilePath = filePath;
        }

        public void AddShape(ShapeBase shape)
        {
            Shapes.Add(shape);
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

        /// <summary>
        /// Updates the current model's data using the provided model instance, ensuring consistency across the application.
        /// </summary>
        public void ImportDataFrom(DrawingModel source)
        {
            ClearShapes();
            foreach (var shape in source.Shapes)
            {
                AddShape(shape);
            }

            SetView(source.ZoomLevel, source.ViewOffset);

            UserData = source.UserData;
        }

    }
}
