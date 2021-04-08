using OnlineLibrarySystemLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLibrarySystemWeb
{
    public partial class CheckOutPage : System.Web.UI.Page
    {
        private List<IResource> _preCheckOutList;

        public object ErrorText { get;  set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        protected void CheckOutBtn_Click(object sender, EventArgs e)
        {
            int userID = GetUserIDFromSession();
            List<int> resourceIDs = GetResourceIdsFromSession();

            try
            {
                CreateAndStoreCheckOut(userID, resourceIDs);
                ClearResourceIdsInSession();

                UpdateUI();
            }
            catch (ArgumentException ex)
            {
                SetErrorText(ex.Message);
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            int resourceID = Int32.Parse(b.CommandName);

            var resourceIds = GetResourceIdsFromSession();
            resourceIds.Remove(resourceID);
            SetResourceIdsToSession(resourceIds);

            UpdateUI();
        }

        protected void UpdateUI()
        {
            var resourceRepository = new ResourceRepository();
            var resourceIds = GetResourceIdsFromSession();

            _preCheckOutList = new List<IResource>();

            if (resourceIds != null)
            {
                resourceIds.ForEach(id =>
                {
                    var resource = resourceRepository.GetByID(id);

                    if (resource != null)
                        _preCheckOutList.Add(resource);
                });
            }

            checkOutRepeater.DataSource = _preCheckOutList;
            checkOutRepeater.DataBind();
        }

        private static void CreateAndStoreCheckOut(int userID, List<int> resourceIDs)
        {
            var checkOut = new OnlineLibrarySystemLib.CheckOut(userID, resourceIDs, DateTime.Now);
            var checkOutRepository = new CheckOutRepository();

            checkOutRepository.Add(checkOut);
        }

        private int GetUserIDFromSession()
        {
            return (int)Session["UserId"];
        }

        private void SetResourceIdsToSession(List<int> resourceIds)
        {
            Session["resourceIds"] = resourceIds;
        }

        private List<int> GetResourceIdsFromSession()
        {
            return (List<int>)Session["resourceIds"];
        }

        private void ClearResourceIdsInSession()
        {
            Session["resourceIds"] = new List<int>();
        }

        private void SetErrorText(string errorText)
        {
            ErrorText = errorText;
        }
    }
}