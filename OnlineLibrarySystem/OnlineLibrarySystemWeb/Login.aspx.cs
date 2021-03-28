using OnlineLibrarySystemLib;
using OnlineLibrarySystemLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLibrarySystemWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var login = new LoginService();
            var isSucceed = login.LoginUser(email.Text.ToLower(), password.Text);

            if (isSucceed)
            {
                var userarch = new UserSearch();
                var user = userarch.FindByEmail(email.Text);
                Session["FirstName"] = user.FirstName;
                Session["UserId"] = user.UserId;
                Session["Email"] = user.Email;
                Session["Role"] = user is Customer ? "Customer" : "Manager";

                Response.Redirect("~/Default.aspx");
            }
            else
                ErrorMessage.Text = "Invalid Credential";
        }
    }
}