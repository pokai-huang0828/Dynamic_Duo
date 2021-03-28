using OnlineLibrarySystemLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLibrarySystemWeb
{
    public partial class WaitingList : System.Web.UI.Page
    {
        private List<WishListItem> _waitList; 
        private List<IResource> _waitListDisplay = new List<IResource>();

        WaitListItemRepository wll_repository;
        ResourceRepository resourceRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            wll_repository = new WaitListItemRepository();
            resourceRepository = new ResourceRepository();

            DisplayWishList();
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            int resourceid = Int32.Parse(b.CommandName);
            int userid = (int)Session["UserId"];

            wll_repository.RemoveByUserIdAndResourceId(userid, resourceid);
            _waitListDisplay = new List<IResource>();

            DisplayWishList();
        }

        protected void DisplayWishList()
        {
            var userId = Session["UserId"];
            if (userId == null) return;

            _waitList = wll_repository.GetAll().Where(w => w.UserID == (int)userId).ToList();

            if (_waitList.Count() != 0)
            {
                (_waitList).ForEach(w =>
                {
                    var resource = resourceRepository.GetByID(w.ResourceID);

                    if (resource != null)
                        _waitListDisplay.Add(resource);
                });
            }

            wishListRepeater.DataSource = _waitListDisplay;
            wishListRepeater.DataBind();
        }

    }
}