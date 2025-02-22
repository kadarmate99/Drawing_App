// Description: The initial window where users choose to create a new file or open an existing one.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing_App_v01
{
    public partial class WelcomeForm : Form
    {
        public event EventHandler<string> FileSelectedToOpen;
        public event EventHandler<string> FileSelectedToCreate;

        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            string filePath = FileDialogHelper.CreateFileDialog();

            if (!string.IsNullOrEmpty(filePath))
            {
                FileSelectedToCreate?.Invoke(this, filePath);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            string filePath = FileDialogHelper.OpenFileDialog();

            if (!string.IsNullOrEmpty(filePath))
            {
                FileSelectedToOpen?.Invoke(this, filePath);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
