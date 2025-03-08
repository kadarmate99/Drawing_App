using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Holds settings related to drawing operations.
/// </summary>
namespace Drawing_App_v01.Presenter
{
    public class DrawingSettings
    {
        public Color DrawingColor { get; set; } = Color.Black;
        public int DrawingLineWidth { get; set; } = 1;
        public int DrawingNodeSize { get; set; } = 5;
    }
}
