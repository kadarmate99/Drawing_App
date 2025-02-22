using Newtonsoft.Json;
using static System.Windows.Forms.AxHost;

namespace Drawing_App_v01.ShapeComponents
{
    [JsonObject(MemberSerialization.OptIn)] //Only properties marked with [JsonProperty] are included in JSON
    public abstract class Shape
    {
        [JsonProperty]
        public Color ShapeColor { get; set; } = Color.Black;
        [JsonProperty]
        public int ShapeLineWeight { get; set; }

        public abstract void Draw(Graphics g);
    }
}
