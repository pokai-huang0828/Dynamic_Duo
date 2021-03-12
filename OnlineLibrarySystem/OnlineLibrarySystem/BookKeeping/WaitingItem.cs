using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystem
{
    public class WaitingItem
    {
        public int WaitingItemID { get; set; }
        public int ResourceID { get; set; }
        public int UserID { get; set; }

        public WaitingItem(int resourceID, int userID)
        {
            ResourceID = resourceID;
            UserID = userID;
        }
    }
}
