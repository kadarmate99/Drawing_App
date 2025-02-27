// Description: Centralized class for managing all drawing-related data

using System.IO;
using Drawing_App_v01.Model.ShapeComponents;

namespace Drawing_App_v01.Model
{
    public class DrawingModel
    {
        public List<ShapeBase> Shapes { get; private set; }

        public string FilePath { get; private set; }

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

        public void ClearSahpes()
        {
            Shapes.Clear();
        }
    }
}
