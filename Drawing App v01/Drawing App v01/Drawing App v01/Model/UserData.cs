using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing_App_v01.Model
{
    /// <summary>
    /// Container for user information associated with a drawing file.
    /// Stores personal details like name, email, and address.
    /// </summary>
    public class UserData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
    }
}
