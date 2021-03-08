using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystem
{
    public class CheckOutItem
    {
        public string CheckOutItemID { get; set; }
        public string CustomerID { get; set; }
        public string ResourceID { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string DueDate { get; set; }
        public Status ItemStatus { get; set; }
    }

    public enum Status
    {
        CHECKOUT,
        DELIVERED,
        INSHELF
    }
}
