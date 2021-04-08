using OnlineLibrarySystemLib;
using OnlineLibrarySystemLib.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLibrarySystemWeb
{
    public partial class UserDetails : System.Web.UI.Page
    {
        private CheckOutRepository checkOutRepository;
        private UserRepository userRepository;

        public String ErrorText = "";

        public UserDetails()
        {
            checkOutRepository = new CheckOutRepository();
            userRepository = new UserRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            string userIdQuery = Request.QueryString["userId"];

            if (userIdQuery == null)
            {
                ErrorText = "Sorry. This url request is invalid.";
                return;
            }

            List<PropertyItem> userDetails = null;
            List<DisplayCheckOutItem> historyDetails = null;

            try
            {
                int userID = Int32.Parse(userIdQuery);

                userDetails = userRepository.GetUserDetails(userID);
                historyDetails = checkOutRepository.GetCheckOutItemsByID(userID);
            }
            catch (Exception ex)
            {
                ErrorText = ex.Message;
            }

            UserDetailPropertyRepeater.DataSource = userDetails;
            UserDetailPropertyRepeater.DataBind();

            historyRepeater.DataSource = historyDetails;
            historyRepeater.DataBind();
        }

        protected void ReturnBtn_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            var IDs = b.CommandName.Split(' ');
            int checkOutID = Int32.Parse(IDs[0]);
            int resourceID = Int32.Parse(IDs[1]);

            CheckOutUtils.ProcessReturnItems(checkOutID, resourceID);
            UpdateUI();
        }
    }
}