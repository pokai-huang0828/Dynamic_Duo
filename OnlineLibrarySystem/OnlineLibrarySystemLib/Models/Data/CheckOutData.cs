using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib.Models.Data
{
    public class CheckOutData
    {
        private static List<CheckOut> _list;
        private static int _lastID;

        private CheckOutData() { }

        public static List<CheckOut> CheckOutList
        {
            get
            {
                if(_list == null)
                {
                    _list = GetCheckouts();
                    _lastID = _list.Count;
                }
                return _list;
            }
        }

        public static int LastID => _lastID;

        public static void IncrementLastID()
        {
            _lastID = _lastID == 0 ? CheckOutList.Count + 1 : _lastID + 1 ;
        }

        private static List<CheckOut> GetCheckouts()
        {
            return new List<CheckOut>() {
                new CheckOut(1, new List<int>() { 1,2,3}, new DateTime(2021, 2, 27)){ ID =1},
                new CheckOut(2, new List<int>() { 4,5,6}, new DateTime(2021, 2, 23)){ ID =2},
                new CheckOut(1, new List<int>() { 4,7,8}, new DateTime(2021, 2, 22)){ ID =3}
            };
        }
    }
}
