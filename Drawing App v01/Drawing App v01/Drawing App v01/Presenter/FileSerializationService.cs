using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Drawing_App_v01.Model.ShapeComponents;


namespace Drawing_App_v01.Presenter
{
    public class FileSerializationService
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented
        };

        public List<Shape> LoadDrawingFromFile(string filePath)
        {

            List<Shape> shapes = new List<Shape>();

            if (File.Exists(filePath))
            {
                try
                {
                    string jsonData = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<List<Shape>>(jsonData, _jsonSerializerSettings) ?? new List<Shape>();
                }
                catch (JsonException ex)
                {
                    MessageBox.Show($"Error deserializing JSON: {ex.Message}", "Error");
                    return new List<Shape>();
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"IO Error: {ex.Message}", "Error");
                    return new List<Shape>();
                }
            }
            else
            {
                MessageBox.Show($"File not found: {filePath}", "Error");
                return new List<Shape>();
            }
        }

        public void SaveDrawingToFile(string filePath, List<Shape> shapes)
        {
            string jsonData = JsonConvert.SerializeObject(shapes, _jsonSerializerSettings);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
