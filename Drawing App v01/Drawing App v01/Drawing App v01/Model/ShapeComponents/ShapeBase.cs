using Newtonsoft.Json;
using System.Drawing;
using static System.Windows.Forms.AxHost;

namespace Drawing_App_v01.Model.ShapeComponents
{
    public abstract class ShapeBase
    {
        public Color ShapeColor { get; set; }
        public int ShapeLineWeight { get; set; }

        public abstract void Draw(Graphics g);
    }
}
