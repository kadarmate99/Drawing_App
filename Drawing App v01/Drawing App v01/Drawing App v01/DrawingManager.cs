// Description: Centralized class for managing all drawing-related data

using System.IO;

namespace Drawing_App_v01
{
    public class DrawingManager
    {
        private FileStream _fileStream;
        public List<Node> Nodes { get; private set; }
        public List<Line> Lines { get; private set; }
        public string FilePath { get; private set; }

        public DrawingManager()
        {
            Nodes = new List<Node>();
            Lines = new List<Line>();
        }

        public void Render(Graphics g)
        {
            foreach (Node node in Nodes)
            {
                g.FillRectangle(Brushes.Black, node.X - node.Size / 2, node.Y - node.Size / 2, node.Size, node.Size);
            }

            
            foreach (Line line in Lines)
            {
                using (Pen pen = new Pen(Color.Black, line.LineWeight))
                {
                    g.DrawLine(pen, line.StartingPoint.X, line.StartingPoint.Y, line.EndingPoint.X, line.EndingPoint.Y);
                }
            }
        }

        public void SetFilePath(string filePath)
        {
            FilePath = filePath;
        }

        public void AddNode(Node node)
        {
            Nodes.Add(node);
        }

        public void RemoveNode(Node node)
        {
            Nodes.Remove(node);
        }

        public void AddLine(Line line)
        {
            Lines.Add(line);
        }

        public void RemoveLine(Line line)
        {
            Lines.Remove(line);
        }

        public void ClearCanvas()
        {
            Nodes.Clear();
            Lines.Clear();
        }

        public void SaveAs(string filePath)
        {
            SetFilePath(filePath);

            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (Node node in Nodes)
                {
                    writer.WriteLine($"{node.X},{node.Y},{node.Size}");
                }
            }
        }

        public void Save()
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (Node node in Nodes)
                {
                    writer.WriteLine($"{node.X},{node.Y},{node.Size}");
                }
            }
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
                                int size = int.Parse(parts[2]);
                                Nodes.Add(new Node(x, y, size));
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
