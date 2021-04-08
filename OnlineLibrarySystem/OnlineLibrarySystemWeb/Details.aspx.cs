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
        private List<PropertyItem> resourceDetails;
        private List<int> borrowedUserIds;
        public string ErrorText = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string resourceIdQuery = Request.QueryString["resourceId"];

            if (resourceIdQuery == null)
            {
                SetErrorText("Sorry. This url request is invalid.");
                return;
            }

            PopulateRepeaters(resourceIdQuery);
        }

        private void PopulateRepeaters(string resourceIdQuery)
        {
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

        private void SetErrorText(string errorText)
        {
            ErrorText = errorText;
        }
    }
}