using OnlineLibrarySystemLib.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib.UnitsOfWork
{
    public class DeliveryService
    {
        public static DeliveryStatus GetDeliveryStatus(int checkoutId)
        {
            return DeliveryStatus.Delivered;
        }
    }
}
