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
            DisplayCheckOutItems();
        }

        protected void CheckOutBtn_Click(object sender, EventArgs e)
        {
            int userID = (int)Session["UserId"];
            List<int> resourceIDs = (List<int>)Session["resourceIds"];
            try
            {
                var checkOut = new OnlineLibrarySystemLib.CheckOut(userID, resourceIDs, DateTime.Now);
                var checkOutRepository = new CheckOutRepository();
                checkOutRepository.Add(checkOut);
                Session["resourceIds"] = new List<int>();
                DisplayCheckOutItems();
            }
            catch(ArgumentException ex)
            {
                ErrorText = ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            int resourceID = Int32.Parse(b.CommandName);

            var resourceIds = (List<int>)Session["resourceIds"];
            resourceIds.Remove(resourceID);
            Session["resourceIds"] = resourceIds;

            DisplayCheckOutItems();
        }

        protected void DisplayCheckOutItems()
        {
            var resourceRepository = new ResourceRepository();

            var resourceIds = Session["resourceIds"];
            _preCheckOutList = new List<IResource>();

            if (resourceIds != null)
            {
                ((List<int>)resourceIds).ForEach(id =>
                {
                    var resource = resourceRepository.GetByID(id);

                    if (resource != null)
                        _preCheckOutList.Add(resource);
                });
            }

            checkOutRepeater.DataSource = _preCheckOutList;
            checkOutRepeater.DataBind();
        }

    }
}