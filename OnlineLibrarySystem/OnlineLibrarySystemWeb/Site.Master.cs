using OnlineLibrarySystemLib;
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
        public WaitListItemRepository waitListItemRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            string currentPath = HttpContext.Current.Request.Path;

            if (Session["UserId"] == null
                && currentPath != "/login" 
                && currentPath != "/register")
                Response.Redirect("~/login");

            if (Session["resourceIds"] == null)
                Session["resourceIds"] = new List<int>();

            waitListItemRepository = new WaitListItemRepository();
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Login");
        }
    }
}