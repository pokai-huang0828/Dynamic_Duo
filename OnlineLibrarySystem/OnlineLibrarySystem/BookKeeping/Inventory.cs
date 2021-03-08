using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineLibrarySystem
{
    public class Inventory
    {
        public List<Resource> ListOfResource { get; set; }

        public void AddToInventory(Resource r) { }
        public void RemoveFromInventory(string ResourceID) { }
        public void CheckOutResource(string resourceID) { }
        public bool IsResourceAvailable(string resourceID) { return true; }
        public Resource SearchresourceByID(string resourceID) { return new Resources.Book(); }

    }
}
