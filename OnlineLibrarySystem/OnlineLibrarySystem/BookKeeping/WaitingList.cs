using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystem
{
    public class WaitingList : IEnumerable
    {
        private List<WaitingItem> _listOfWaitingItem;
        private int _lastWaitingItemID;

        public WaitingList()
        {
            _listOfWaitingItem = new List<WaitingItem>();
            _lastWaitingItemID = 0;
        }

        public void AddToWaitingList(WaitingItem wi) 
        {
            wi.WaitingItemID = ++_lastWaitingItemID;
            _listOfWaitingItem.Add(wi);
        }

        public void RemoveWaitingItemById(int waitingItemID) 
        {
            _listOfWaitingItem.RemoveAll(w => w.WaitingItemID == waitingItemID);
        }

        public WaitingItem GetFirstWaitingItemByResourceID(int resourceID) 
        { 
            return _listOfWaitingItem.FirstOrDefault(w => w.ResourceID == resourceID); 
        }

        public IEnumerator GetEnumerator()
        {
            foreach(WaitingItem w in _listOfWaitingItem)
            {
                yield return w;
            }
        }

    }
}
