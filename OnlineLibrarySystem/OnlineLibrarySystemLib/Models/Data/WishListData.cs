using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib.Models.Data
{
    public class WishListData
    {
        private static List<WishListItem> _list;
        private static int _lastID;

        private WishListData() { }

        public static List<WishListItem> WishListItems
        {
            get
            {
                if (_list == null)
                {
                    _list = GetWishListItems();
                    _lastID = _list.Count;
                }
                return _list;
            }
        }

        public static int LastID => _lastID;

        public static void IncrementLastID()
        {
            ++_lastID;
        }

        private static List<WishListItem> GetWishListItems()
        {
            return new List<WishListItem>() {
                    new WishListItem(1, 3),
                    new WishListItem(2, 4),
                    new WishListItem(1, 6)
            };
        }
    }
}
