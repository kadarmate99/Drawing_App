// Description: Centralized class for managing all drawing-related data

using System.IO;
using Drawing_App_v01.ShapeComponents;

namespace Drawing_App_v01
{
    public class DrawingManager
    {
        private FileStream _fileStream;
        public List<Shape> Shapes { get; private set; }
        
        public string FilePath { get; private set; }

        public DrawingManager()
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

        public void ClearCanvas()
        {
            Shapes.Clear();
        }

        public void SaveAs(string filePath)
        {
            //SetFilePath(filePath);

            //using (StreamWriter writer = new StreamWriter(FilePath))
            //{
            //    foreach (Node node in Nodes)
            //    {
            //        writer.WriteLine($"{node.X},{node.Y},{node.ShapeLineWeight}");
            //    }
            //}
        }

        public void Save()
        {
            //using (StreamWriter writer = new StreamWriter(FilePath))
            //{
            //    foreach (Node node in Nodes)
            //    {
            //        writer.WriteLine($"{node.X},{node.Y},{node.ShapeLineWeight}");
            //    }
            //}
        }

        public void LoadDrawingFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                ClearCanvas();
                SetFilePath(filePath);

                try
                {
                    using (_fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                    {
                        using (StreamReader reader = new StreamReader(_fileStream))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                var parts = line.Split(',');
                                int x = int.Parse(parts[0]);
                                int y = int.Parse(parts[1]);
                                int ShapeWidth = int.Parse(parts[2]);
                                Shapes.Add(new Node(x, y, ShapeWidth));
                            }
                        }
                    }
                }
                catch (IOException e)
                {
                    MessageBox.Show($"File is in use or cannot be Opend. \n\n{e.Message} ", "Error: Drawing.LoadDrawingFile");
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error Message: \n\n{e.Message} ", "Error");
                }

            }
            else
            {
                throw new FileNotFoundException($"The file at {filePath} does not exist.");
            }
        }

        public void DisposeDrawingFile()
        {
            _fileStream?.Dispose();
        }

    }
}
