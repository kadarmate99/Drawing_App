using System.IO;
using Drawing_App_v01.Model.ShapeComponents;

namespace Drawing_App_v01.Model
{
    /// <summary>
    /// Centralized class for managing all drawing-related data, including shapes,
    /// user information, and view settings.
    /// </summary>
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

        /// <summary>
        /// Renders all shapes in the model to the specified graphics context.
        /// </summary>
        /// <param name="g">The graphics context to draw on.</param>
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
        /// Imports data from another drawing model instance, replacing the current model's content.
        /// </summary>
        /// <param name="source">The source model to import from.</param>
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
