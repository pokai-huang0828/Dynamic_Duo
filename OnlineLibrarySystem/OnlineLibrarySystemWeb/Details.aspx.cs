using OnlineLibrarySystemLib;
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
        private IResource resource;
        public String ErrorText = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string resourceIdQuery = Request.QueryString["resourceId"];

            if (resourceIdQuery == null)
            {
                ErrorText = "Sorry. This url is invalid.";
                return;
            }

            int resourceID = Int32.Parse(resourceIdQuery);
           
            DetailPropertyRepeater.DataSource = ResourceDetails(resourceID);
            DetailPropertyRepeater.DataBind();
        }

        private List<PropertyItem> ResourceDetails(int resourceID)
        {
            ResourceRepository resourceRepository = new ResourceRepository();
            resource = resourceRepository.GetByID(resourceID);
            if (resource == null)
            {
                ErrorText = "Sorry. The item you requested is not available.";
                return null;
            }

            var properties = new List<PropertyItem>();

            foreach (var property in resource.GetType().GetProperties())
            {
                StringBuilder sb = new StringBuilder();

                var charArray = (property.Name).ToCharArray();

                foreach (var letter in charArray)
                {
                    if (!Char.IsUpper(letter))
                        sb.Append(letter);
                    else
                        sb.Append(" " + letter);
                }

                properties.Add(
                    new PropertyItem(sb.ToString(), property.GetValue(resource)));
            }

            var resourceIDProperty = properties.Find(p => p.Key == " Resource I D");
            if (resourceIDProperty != null)
                resourceIDProperty.Key = " Resource ID";

            properties.Sort((p, k) => p.Key.CompareTo(k.Key));

            return properties;

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