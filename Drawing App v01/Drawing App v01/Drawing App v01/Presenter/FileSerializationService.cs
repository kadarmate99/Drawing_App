using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Drawing_App_v01.Model.ShapeComponents;
using Drawing_App_v01.Model;


namespace Drawing_App_v01.Presenter
{
    /// <summary>
    /// Handles serialization and deserialization of the drawing model to and from JSON files.
    /// </summary>
    public class FileSerializationService
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented
        };

        /// <summary>
        /// Loads a drawing from a JSON file.
        /// </summary>
        /// <param name="filePath">The path to the file to load.</param>
        /// <returns>A populated DrawingModel, or a new empty model if loading fails.</returns>
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

                    //Load User Data
                    drawingModel.UserData = JsonConvert.DeserializeObject<UserData>(loadData.UserData.ToString());

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

        /// <summary>
        /// Saves a drawing model to a JSON file.
        /// </summary>
        /// <param name="filePath">The path where the file should be saved.</param>
        /// <param name="model">The drawing model to save.</param>
        public void SaveDrawingToFile(string filePath, DrawingModel model)
        {
            var saveData = new
            {
                Shapes = model.Shapes,
                ZoomLevel = model.ZoomLevel,
                ViewOffset = model.ViewOffset,
                UserData = model.UserData
            };

            string jsonData = JsonConvert.SerializeObject(saveData, _jsonSerializerSettings);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
