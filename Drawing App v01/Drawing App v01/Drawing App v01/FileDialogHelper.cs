using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Description: Handles save/load functionality, ensuring object data is preserved.

namespace Drawing_App_v01
{
    public static class FileDialogHelper
    {
        public static string OpenFileDialog()
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "JSON Files(*.json) | *.json",
                Title = "Select a file to load"
            };
            return openFileDialog.ShowDialog() == DialogResult.OK ? openFileDialog.FileName : string.Empty;
        }

        public static string SaveFileDialog()
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog()
            { 
                Filter = "JSON Files(*.json) | *.json",
                Title = "Set path and file name to save the drawing"
            };
            return saveFileDialog.ShowDialog() == DialogResult.OK ? saveFileDialog.FileName : string.Empty;
        }

        public static string CreateFileDialog()
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog()
            { 
                Filter = "JSON Files(*.json) | *.json",
                Title = "Create a file to load"
            };
            return saveFileDialog.ShowDialog() == DialogResult.OK ? saveFileDialog.FileName : string.Empty;
        }
    }

}
