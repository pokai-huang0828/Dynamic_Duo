using OnlineLibrarySystemLib;
using OnlineLibrarySystemLib.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLibrarySystemWeb
{
    public partial class CheckOutStatus : System.Web.UI.Page
    {
        public DeliveryStatus deliveryStatus;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckOutRepository checkOutRepository = new CheckOutRepository();
            
            int checkoutId;

            if (Int32.TryParse(Request.QueryString["checkOutId"], out checkoutId)) 
            {
                var checkOutItem = checkOutRepository.GetByID(checkoutId);

                if (checkOutItem != null)
                    deliveryStatus = checkOutItem.deliveryStatus;
                else
                    deliveryStatus = DeliveryStatus.Unknown;

                return;
            };
            
            deliveryStatus = DeliveryStatus.Unknown;

        }
    }
}