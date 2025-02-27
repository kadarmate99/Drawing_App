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

        public List<ShapeBase> LoadDrawingFromFile(string filePath)
        {

            List<ShapeBase> shapes = new List<ShapeBase>();

            if (File.Exists(filePath))
            {
                try
                {
                    string jsonData = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<List<ShapeBase>>(jsonData, _jsonSerializerSettings) ?? new List<ShapeBase>();
                }
                catch (JsonException ex)
                {
                    MessageBox.Show($"Error deserializing JSON: {ex.Message}", "Error");
                    return new List<ShapeBase>();
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"IO Error: {ex.Message}", "Error");
                    return new List<ShapeBase>();
                }
            }
            else
            {
                MessageBox.Show($"File not found: {filePath}", "Error");
                return new List<ShapeBase>();
            }
        }

        public void SaveDrawingToFile(string filePath, List<ShapeBase> shapes)
        {
            string jsonData = JsonConvert.SerializeObject(shapes, _jsonSerializerSettings);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
