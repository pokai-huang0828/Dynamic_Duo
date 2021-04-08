using OnlineLibrarySystemLib;
using OnlineLibrarySystemLib.Services;
using OnlineLibrarySystemLib.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLibrarySystemWeb
{
    public partial class Details : System.Web.UI.Page
    {
        public String ErrorText = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string resourceIdQuery = Request.QueryString["resourceId"];

            if (resourceIdQuery == null)
            {
                ErrorText = "Sorry. This url request is invalid.";
                return;
            }

            List<PropertyItem> resourceDetails = null;
            List<int> borrowedUserIds = null;

            try
            {
                int resourceID = Int32.Parse(resourceIdQuery);
                ResourceRepository resourceRepository = new ResourceRepository();

                resourceDetails = resourceRepository.GetResourceDetails(resourceID);
                borrowedUserIds = CheckOutUtils.ReturnUserIdsOfABorrowingResource(resourceID);
            }
            catch (Exception ex)
            {
                ErrorText = ex.Message;
            }

            DetailPropertyRepeater.DataSource = resourceDetails;
            DetailPropertyRepeater.DataBind();

            BorrowedUsersRepeater.DataSource = borrowedUserIds;
            BorrowedUsersRepeater.DataBind();
        }
        
    }
}