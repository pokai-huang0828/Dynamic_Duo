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
            var checkoutId = ParseCheckOutIdQuery();

            var checkOutRepository = new CheckOutRepository();
            var checkOutItem = checkOutRepository.GetByID(checkoutId);

            if (checkOutItem != null)
            {
                deliveryStatus = checkOutItem.deliveryStatus;
                return;
            };

            deliveryStatus = DeliveryStatus.Unknown;
        }

        private int ParseCheckOutIdQuery()
        {
            int.TryParse(GetCheckOutIdQuery(), out int checkoutId);
            return checkoutId;
        }

        private string GetCheckOutIdQuery()
        {
            return Request.QueryString["checkOutId"];
        }
    }
}