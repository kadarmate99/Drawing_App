using Drawing_App_v01.Model;
using Drawing_App_v01.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing_App_v01.View
{
    /// <summary>
    /// Form for collecting and editing user information associated with the drawing file.
    /// </summary>
    public partial class UserDataForm : Form
    {
        private readonly UserDataPresenter _presenter;

        public UserDataForm(UserDataPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;
            presenter.SetView(this); // Give the presenter a reference to the form
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var errors = _presenter.ValidateUserData(txtName.Text, txtEmail.Text, dtpDateOfBirth.Text, txtAddress.Text, txtPostalCode.Text);

            if (errors.Count == 0)
            {
                _presenter.SaveUserData(txtName.Text, txtEmail.Text, dtpDateOfBirth.Text, txtAddress.Text, txtPostalCode.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                ShowErrorMessage(string.Join("\n", errors));
            }
        }

        internal void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Loads user data from the model into the form fields.
        /// </summary>
        /// <param name="model">The drawing model containing user data.</param>
        internal void LoadUserData(DrawingModel model)
        {
            txtName.Text = model.UserData.Name;
            txtEmail.Text = model.UserData.Email;
            dtpDateOfBirth.Text = model.UserData.DateOfBirth;
            txtAddress.Text = model.UserData.Address;
            txtPostalCode.Text = model.UserData.PostalCode;
        }
    }
}
