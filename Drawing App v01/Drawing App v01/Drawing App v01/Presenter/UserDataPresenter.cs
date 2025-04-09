using Drawing_App_v01.Model;
using Drawing_App_v01.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Drawing_App_v01.Presenter
{
    /// <summary>
    /// Coordinates interaction between the user data form and the model.
    /// Handles validation and persistence of user information.
    /// </summary>
    public class UserDataPresenter
    {
        private readonly DrawingModel _model;
        private UserDataForm _view;

        public UserDataPresenter(DrawingModel model)
        {
            _model = model;
        }

        /// <summary>
        /// Method to access the UserDataForm (view) through controlled initialization
        /// </summary>
        public void SetView(UserDataForm view)
        {
            if (_view == null)
            {
                _view = view;
                _view.LoadUserData(_model);
            }
        }

        /// <summary>
        /// Validates user input data for completeness and format correctness.
        /// </summary>
        /// <returns>A list of validation errors, or an empty list if validation passed.</returns>
        public List<string> ValidateUserData(string name, string email, string dateOfBirth, string address, string postalCode)
        {
            List<string> errors = new List<string>();

            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            var nameRegex = new Regex(@"^(?=.*\p{L})[\p{L}\s.'-]+$");
            var postalCodeRegex = new Regex(@"^\d{4,}$");

            if (string.IsNullOrWhiteSpace(name) || !nameRegex.IsMatch(name))
                errors.Add("Invalid name.");

            if (string.IsNullOrWhiteSpace(email) || !emailRegex.IsMatch(email))
                errors.Add("Invalid email format.");

            if (!DateTime.TryParse(dateOfBirth, out var dob) || dob > DateTime.Now)
                errors.Add("Invalid date of birth.");

            if (string.IsNullOrWhiteSpace(address))
                errors.Add("Invalid Address.");

            if (!postalCodeRegex.IsMatch(postalCode))
                errors.Add("Invalid postal code.");

            return errors;
        }

        public void SaveUserData(string name, string email, string dateOfBirth, string address, string postalCode)
        {
            _model.UserData.Name = name;
            _model.UserData.Email = email;
            _model.UserData.DateOfBirth = dateOfBirth;
            _model.UserData.Address = address;
            _model.UserData.PostalCode = postalCode;
        }
    }
}
