using OnlineLibrarySystemLib;
using OnlineLibrarySystemLib.Services;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLibrarySystemWeb
{
    public partial class _Default : Page
    {
        private  readonly ResourceRepository resourceRepository; 
        private readonly ResourceSearch resourceSearch;

        // private  readonly UserRepository  userRepository; 
        private readonly UserSearch userSearch;

        public _Default()
        {
            resourceRepository = new ResourceRepository();
            resourceSearch = new ResourceSearch();

            // userRepository = new UserRepository();
            userSearch = new UserSearch();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            resourceRepeater.DataSource = resourceRepository.GetAll();
            resourceRepeater.DataBind();
        }

        protected void AddToWistListBtn_Click(object sender, EventArgs e)
        {
            var addToCartBtn = sender as Button;
            var resourceId = Int32.Parse(addToCartBtn.CommandName);
            var userId = (int)Session["UserId"];

            var waitListItemRepository = new WaitListItemRepository();
            waitListItemRepository.Add(new WishListItem(userId, resourceId));
        }

        protected void AddToCartBtn_Click(object sender, EventArgs e)
        {
            var addToCartBtn = sender as Button;
            var resourceId = Int32.Parse(addToCartBtn.CommandName);

            if (Session["resourceIds"] != null)
            {
                ((List<int>)Session["resourceIds"]).Add(resourceId);
                return;
            }

            Session["resourceIds"] = new List<int> { resourceId };
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            var keyword = searchText.Text;
            var category = ddlCategory.SelectedItem.Value;
            var searchType = ddlSearchType.SelectedItem.Value;
            
            resourceRepeater.DataSource = 
                resourceSearch.SearchRespository(keyword, category, searchType);
            resourceRepeater.DataBind();

            searchText.Text = "";
            userRepeater.Visible = false;
            resourceRepeater.Visible = true;
        }

        protected void UserSearchBtn_Click(object sender, EventArgs e)
        {
            var keyword = userSearchText.Text;
            var category = DDLUserByCategory.SelectedItem.Value;
            var searchType = DDLUserSearchBy.SelectedItem.Value;

            userRepeater.DataSource =
                userSearch.SearchRespository(keyword, category, searchType);
            userRepeater.DataBind();

            userSearchText.Text = "";
            resourceRepeater.Visible = false;
            userRepeater.Visible = true;
        }
    }
}