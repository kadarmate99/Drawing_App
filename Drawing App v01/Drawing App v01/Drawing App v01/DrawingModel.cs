// Description: Centralized class for managing all drawing-related data

using System.IO;
using Drawing_App_v01.ShapeComponents;

namespace Drawing_App_v01
{
    public class DrawingModel
    {
        private FileStream _fileStream;
        public List<Shape> Shapes { get; private set; }
        
        public string FilePath { get; private set; }

        public DrawingModel()
        {
            Shapes = new List<Shape>();
        }

        public void Render(Graphics g)
        {
            foreach (Shape shape in Shapes)
            {
                shape.Draw(g);
            }
        }

        public void SetFilePath(string filePath)
        {
            FilePath = filePath;
        }

        public void AddShape(Shape shape)
        {
            Shapes.Add(shape);
        }

        public void RemoveShape(Shape shape)
        {
            Shapes.Remove(shape);
        }

        public void ClearSahpes()
        {
            Shapes.Clear();
        }
    }
}
