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

        private void frmWelcomeForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "CSV Files|*.csv",
                Title = "Load an existing a Drawing File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // possible memory leak problem
                FileSelectedToLoad?.Invoke(this, openFileDialog.FileName);

                               
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
