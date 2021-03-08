using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystem
{
    class Inventory
    {
        public List<Resource> ListOfResource { get; set; }

        public void CheckOutResource(string resourceID) { }
        public bool IsResourceAvailable(string resourceID) { return true; }
        public Resource SearchresourceByID(string resourceID) { return new Resource(); }

    }
}
