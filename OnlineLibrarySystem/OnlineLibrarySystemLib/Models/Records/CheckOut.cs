using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib
{
    public class CheckOut
    {
        public CheckOut()
        {
            ResourceIDs = new List<int>();
        }
        
        public int ID { get; set; }
        public int UserID { get; set; }
        public List<int> ResourceIDs { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime DueDate { get; set; }

    }
}
