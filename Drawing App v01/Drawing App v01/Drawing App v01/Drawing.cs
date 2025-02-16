namespace Drawing_App_v01
{
    public class Drawing
    {
        public List<Node> Nodes { get; private set; }
        public string FilePath { get; private set; }

        public Drawing()
        {
            Nodes = new List<Node>();
        }

        public void Render(Graphics g)
        {
            foreach (Node node in Nodes)
            {
                g.FillRectangle(Brushes.Black, node.X - node.Size / 2, node.Y - node.Size / 2, node.Size, node.Size);
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

        public void ClearCanvas()
        { 
            Nodes.Clear();
        }

        public void SaveAs(string filePath)
        {
            SetFilePath (filePath);

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

        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                ClearCanvas();
                SetFilePath(filePath);
                foreach (var line in File.ReadLines(FilePath))
                {
                    var parts = line.Split(',');
                    int x = int.Parse(parts[0]);
                    int y = int.Parse(parts[1]);
                    int size = int.Parse(parts[2]);
                    Nodes.Add(new Node(x, y, size));
                }
            }
            else
            {
                throw new FileNotFoundException($"The file at {filePath} does not exist.");
            }
        }

    }
}
