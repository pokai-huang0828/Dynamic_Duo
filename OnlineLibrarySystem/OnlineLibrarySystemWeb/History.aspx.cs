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
        private List<DisplayCheckOutItem> _checkOutItems = new List<DisplayCheckOutItem>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            Response.Redirect("~/login");

            var resourceRepository = new ResourceRepository();
            var checkOutRepository = new CheckOutRepository();

            checkOutRepository
                .GetAll()
                .Where(c => c.UserID == (int)Session["UserId"])
                .ToList()
                .ForEach(c =>
                {
                    foreach (var resourceId in c.ResourceIDs)
                    {
                        var r = resourceRepository.GetByID(resourceId);
                        var o = new DisplayCheckOutItem(r.ResourceID, r.Title, c.DueDate);
                        _checkOutItems.Add(o);
                    }
                });

            _checkOutItems.Sort((c, d) => d.DueDate.CompareTo(c.DueDate));

            historyRepeater.DataSource = _checkOutItems;
            historyRepeater.DataBind();
        }
    }

    public class DisplayCheckOutItem
    {
        public DisplayCheckOutItem(int resourceId, string title, DateTime dateTime)
        {
            ResourceId = resourceId;
            Title = title;
            DueDate = dateTime;
        }

        public int ResourceId { get; }
        public string Title { get; }
        public DateTime DueDate { get; }
    }
}