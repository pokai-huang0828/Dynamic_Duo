using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystem
{
    public class WaitingList
    {
        public List<WaitingItem> ListOfWaitingItem { get; set; }

        public void AddToWaitingList(WaitingItem wi) { }
        public bool IsResourceInWaitingList(string resourceID) { return true; }
        public void RemoveFirstResourceById(string resoruceID) { }
    }
}
