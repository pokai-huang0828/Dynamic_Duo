using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLibrarySystemWeb
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentPath = HttpContext.Current.Request.Path;
            if (Session["Email"] == null
                && currentPath != "/login" 
                && currentPath != "/register")
                Response.Redirect("~/login");
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Login");
        }
    }
}