using OnlineLibrarySystemLib;
using OnlineLibrarySystemLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLibrarySystemWeb
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var register = new RegisterService();
            IUser newUser;

            if (customer.Checked)
            {
                newUser = new Customer(email.Text, password.Text)
                {
                    FirstName = firstName.Text,
                    LastName = lastName.Text,
                    Email = email.Text
                };
            }
            else
            {
                newUser = new Manager(email.Text, password.Text)
                {
                    FirstName = firstName.Text,
                    LastName = lastName.Text,
                    Email = email.Text
                };
            }

            int? userId = register.RegisterUser(newUser);

            if (userId != null)
                Response.Redirect("~/Default");
            else
                ErrorMessage.Text = "This email address is already being used.";
        }
    }
}