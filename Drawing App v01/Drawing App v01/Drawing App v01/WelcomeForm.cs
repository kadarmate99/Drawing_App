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
        public event EventHandler<string> FileSelectedToLoad;

        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {

        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            string filePath = FileHandler.OpenFileDialog();

            if (filePath != "")
            {
                FileSelectedToLoad?.Invoke(this, filePath);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
