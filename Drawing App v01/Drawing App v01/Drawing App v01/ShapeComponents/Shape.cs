using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing_App_v01.ShapeComponents
{
    public abstract class Shape
    {
        public Color ShapeColor { get; set; } = Color.Black;
        public int ShapeLineWeight { get; set; }

        public abstract void Draw(Graphics g);
    }
}
