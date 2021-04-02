using OnlineLibrarySystemLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLibrarySystemWeb
{    
    public partial class History : System.Web.UI.Page
    {
        private CheckOutRepository checkOutRepository;

        public History()
        {
            checkOutRepository = new CheckOutRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
                Response.Redirect("~/login");

            int userId = (int)Session["UserId"];

            historyRepeater.DataSource =
                checkOutRepository.GetCheckOutItemsByID(userId);
            historyRepeater.DataBind();
        }
    }

}