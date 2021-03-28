using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib
{
    public class CheckOut
    {
        public CheckOut(
            int userID, 
            List<int> resourceIDs,
            DateTime checkOutDate
            )
        {
            UserID = userID;
            ResourceIDs = resourceIDs;
            DueDate = checkOutDate.AddDays(14);
        }
        
        public int ID { get; set; }
        public int UserID { get; set; }
        public List<int> ResourceIDs { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime DueDate { get; set; }

        public override string ToString()
        {
            return "CheckOutID " + ID.ToString() + 
                " UserID" + UserID + " ResourceId " + ResourceIDs.ToString();
        }

    }
}
