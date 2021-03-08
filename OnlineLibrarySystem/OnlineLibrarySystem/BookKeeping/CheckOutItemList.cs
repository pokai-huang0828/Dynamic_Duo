using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystem
{
    public class CheckOutItemList
    {
        public List<CheckOutItemList> ListOfcheckOutItem { get; set; }

        /*reutrn the checkout item id*/
        public string AddToCheckOutItemList(CheckOutItem c) { return ""; }

        public void RemoveFromCheckOutItemList(string c) {  }
    }
}
