using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystem
{
    public class CheckOut
    {
        public int CheckOutID { get; set; }
        public int UserID { get; set; }
        public List<int> ResourceIDList { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDelivered { get; set; }

        public CheckOut(int userID, List<int> resourceIDList, DateTime checkOutDate, DateTime dueDate)
        {
            UserID = userID;
            ResourceIDList = resourceIDList;
            CheckOutDate = checkOutDate;
            DueDate = dueDate;
            IsDelivered = false;
        }

    }
}
