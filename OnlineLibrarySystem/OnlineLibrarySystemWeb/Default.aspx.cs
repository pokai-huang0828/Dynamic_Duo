using OnlineLibrarySystemLib;
using OnlineLibrarySystemLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLibrarySystemWeb
{
    public partial class _Default : Page
    {
        private ResourceRepository resourceRepository; 
        private ResourceSearch resourceSearch;
        
        private UserRepository  userRepository; 
        private UserSearch userSearch; 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            resourceRepository = new ResourceRepository();
            resourceSearch = new ResourceSearch();
            
            userRepository = new UserRepository();
            userSearch = new UserSearch();

            resourceRepeater.DataSource = resourceRepository.GetAll();
            resourceRepeater.DataBind();
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            var results = new List<IResource>();
            var keyword = searchText.Text;

            var category = ddlCategory.SelectedItem.Value;
            var searchType = ddlSearchType.SelectedItem.Value;

            switch (searchType)
            {
                case "name":
                    results = resourceSearch.FindByName(keyword).ToList();
                    break;
                case "resourceId":
                    int number;
                    if (Int32.TryParse(keyword, out number))
                    {
                        var result = resourceRepository.GetByID(number);
                        if(result != null)
                            results.Add(result);
                        break;
                    }
                    break;
                default:
                    results = resourceRepository.GetAll().ToList();
                    break;
            }

            switch (category)
            {
                case "reading":
                    results = results.Where(r => r is IReading).ToList();
                    break;
                case "audio":
                    results = results.Where(r => r is IAudio).ToList();
                    break;
                case "video":
                    results = results.Where(r => r is IVideo).ToList();
                    break;
            }

            userRepeater.Visible = false;
            resourceRepeater.DataSource = results;
            resourceRepeater.DataBind();
            resourceRepeater.Visible = true;
        }

        protected void UserSearchBtn_Click(object sender, EventArgs e)
        {
            var results = new List<IUser>();
            var keyword = userSearchText.Text;

            var category = DDLUserByCategory.SelectedItem.Value;
            var searchType = DDLUserSearchBy.SelectedItem.Value;

            switch (searchType)
            {
                case "name":
                    results = userSearch.FindByName(keyword).ToList();
                    break;
                case "userId":
                    int number;
                    if (Int32.TryParse(keyword, out number))
                    {
                        var result = userRepository.GetByID(number);
                        if (result != null)
                            results.Add(result);
                        break;
                    }
                    break;
                default:
                    results = userRepository.GetAll().ToList();
                    break;
            }

            switch (category)
            {
                case "customer":
                    results = results.Where(u => u is Customer).ToList();
                    break;
                case "manager":
                    results = results.Where(m => m is Manager).ToList();
                    break;
            }

            resourceRepeater.Visible = false;

            userRepeater.DataSource = results;
            userRepeater.DataBind();

            userRepeater.Visible = true;
        }
    }
}