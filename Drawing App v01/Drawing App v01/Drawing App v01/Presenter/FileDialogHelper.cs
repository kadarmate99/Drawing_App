using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Drawing_App_v01.Presenter
{
    /// <summary>
    /// Static utility class for file operations like opening and saving drawing files.
    /// </summary>
    public static class FileDialogHelper
    {
        /// <summary>
        /// Displays an open file dialog and returns the selected file path.
        /// </summary>
        /// <returns>The selected file path, or an empty string if canceled.</returns>
        public static string OpenFileDialog()
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "JSON Files(*.json) | *.json",
                Title = "Select a file to load"
            };
            return openFileDialog.ShowDialog() == DialogResult.OK ? openFileDialog.FileName : string.Empty;
        }

        /// <summary>
        /// Displays a save file dialog and returns the selected file path.
        /// </summary>
        /// <returns>The selected file path, or an empty string if canceled.</returns>
        public static string SaveFileDialog()
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "JSON Files(*.json) | *.json",
                Title = "Set path and file name to save the drawing"
            };
            return saveFileDialog.ShowDialog() == DialogResult.OK ? saveFileDialog.FileName : string.Empty;
        }

        /// <summary>
        /// Displays a save file dialog for creating new files and returns the selected file path.
        /// </summary>
        /// <returns>The selected file path, or an empty string if canceled.</returns>
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
