using OnlineLibrarySystemLib.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib
{
    public class WaitListItemRepository : ILibraryRespository<WishListItem>
    {
        public int Add(WishListItem item)
        {
            WishListData.IncrementLastID();
            item.ID = WishListData.LastID;
            WishListData.WishListItems.Add(item);

            return item.ID;
        }

        public IEnumerable<WishListItem> GetAll()
        {
            return WishListData.WishListItems.ToList();
        }

        public WishListItem GetByID(int id)
        {
            return WishListData.WishListItems.FirstOrDefault(w => w.ID == id);
        }

        public void RemoveByID(int id)
        {
            WishListData.WishListItems.RemoveAll(w => w.ID == id);
        }

        public void RemoveByUserIdAndResourceId(int userId, int resourceId)
        {
            var item = WishListData.WishListItems.Find(w => w.UserID == userId && w.ResourceID == resourceId);
            WishListData.WishListItems.Remove(item);
        }

        public WishListItem Update(WishListItem updatedItem)
        {
            throw new NotImplementedException();
        }
    }
}
