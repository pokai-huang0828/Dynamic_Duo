using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystem
{
    public class CheckOutList :IEnumerable
    {
        private List<CheckOut> _listOfCheckOut;
        private int _lastCheckOutID;

        public CheckOutList()
        {
            _listOfCheckOut = new List<CheckOut>();
            _lastCheckOutID = 0;
        }

        /*reutrn the checkout item id*/
        public int AddToCheckOutList(CheckOut checkout) 
        {
            checkout.CheckOutID = ++_lastCheckOutID; 
            _listOfCheckOut.Add(checkout);
            return _lastCheckOutID; 
        }

        public void RemoveFromCheckOutList(int checkOutID) 
        {
            _listOfCheckOut.RemoveAll(checkout => checkout.CheckOutID == checkOutID);
        }

        public IEnumerator GetEnumerator()
        {
            foreach(CheckOut c in _listOfCheckOut)
            {
                yield return c;
            }
        }
    }
}
