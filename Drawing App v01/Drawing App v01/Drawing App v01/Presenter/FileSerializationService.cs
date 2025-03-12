using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Drawing_App_v01.Model.ShapeComponents;
using Drawing_App_v01.Model;


namespace Drawing_App_v01.Presenter
{
    public class FileSerializationService
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented
        };

        public DrawingModel LoadDrawingFromFile(string filePath)
        { 
            if (File.Exists(filePath))
            {
                try
                {
                    string jsonData = File.ReadAllText(filePath);
                    dynamic loadData = JsonConvert.DeserializeObject(jsonData);

                    DrawingModel drawingModel = new DrawingModel();

                    // Load View settings
                    drawingModel.SetView((float)loadData.ZoomLevel, new PointF((float)loadData.ViewOffset.X, (float)loadData.ViewOffset.Y));

                    // Load Shapes
                    foreach (var shapeData in loadData.Shapes)
                    {
                        ShapeBase shape = JsonConvert.DeserializeObject<ShapeBase>(shapeData.ToString(), _jsonSerializerSettings);
                        drawingModel.AddShape(shape);
                    }
                    return drawingModel;
                }
                catch (JsonException ex)
                {
                    MessageBox.Show($"Error deserializing JSON: {ex.Message}", "Error");
                    return new DrawingModel();
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"IO Error: {ex.Message}", "Error");
                    return new DrawingModel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception: {ex.Message}", "Error");
                    return new DrawingModel();
                }
            }
            else
            {
                MessageBox.Show($"File not found: {filePath}", "Error");
                return new DrawingModel();
            }

            
        }

        public void SaveDrawingToFile(string filePath, List<ShapeBase> shapes, float zoomLevel, PointF viewOffset )
        {
            var saveData = new
            {
                Shapes = shapes,
                ZoomLevel = zoomLevel,
                ViewOffset = viewOffset
            };

            string jsonData = JsonConvert.SerializeObject(saveData, _jsonSerializerSettings);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
