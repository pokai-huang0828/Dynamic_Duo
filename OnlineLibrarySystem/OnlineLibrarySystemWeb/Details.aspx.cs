using OnlineLibrarySystemLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLibrarySystemWeb
{
    public partial class Details : System.Web.UI.Page
    {
        private IResource resource;

        protected void Page_Load(object sender, EventArgs e)
        {
            string resourceIdQuery = Request.QueryString["resourceId"];
            if (resourceIdQuery == null) return;

            int resourceID = Int32.Parse(resourceIdQuery);

            ResourceRepository resourceRepository = new ResourceRepository();
            resource = resourceRepository.GetByID(resourceID);
            if (resource == null) return;

            var properties = new List<PropertyItem>();

            foreach (var property in resource.GetType().GetProperties())
            {
                properties.Add(
                    new PropertyItem(property.Name, property.GetValue(resource)));
            }

            DetailPropertyRepeater.DataSource = properties;
            DetailPropertyRepeater.DataBind();
        }

        private class PropertyItem
        {
            public PropertyItem(String key, object value)
            {
                Key = key;
                Value = value;
            }
            public String Key { get; set; }
            public object Value { get; set; }
        }
        
    }
}