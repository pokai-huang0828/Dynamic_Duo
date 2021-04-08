using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib.Models.Enum
{
    public enum DeliveryStatus
    {
        AwaitingPickUp,
        InWarehouse,
        InTransit,
        OutForDelivery,
        Delivered,
        Unknown
    }
}
