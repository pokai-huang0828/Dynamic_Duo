using OnlineLibrarySystemLib.Models.Data;
using OnlineLibrarySystemLib.Models.Enum;
using OnlineLibrarySystemLib.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace OnlineLibrarySystemLib
{
    public class CheckOutRepository : ILibraryRespository<CheckOut>
    {
        public int Add(CheckOut item)
        {
            CheckOutUtils.ProcessCheckOut(item); // throws exceptions if the check out is invalid
            CheckOutData.IncrementLastID();
            item.ID = CheckOutData.LastID;
            CheckOutData.CheckOutList.Add(item);

            return item.ID;
        }

        public IEnumerable<CheckOut> GetAll()
        {
            return CheckOutData.CheckOutList.ToList();
        }

        public CheckOut GetByID(int id)
        {
            return CheckOutData.CheckOutList.FirstOrDefault(c => c.ID == id);
        }

        public void RemoveByID(int id)
        {
            var checkout = GetByID(id);
            if (checkout == null)
                return;

            CheckOutUtils.RemoveCheckOut(checkout);
            CheckOutData.CheckOutList.RemoveAll(c => c.ID == id);
        }

        public CheckOut Update(CheckOut updatedItem)
        {
            if (updatedItem == null)
                throw new ArgumentException("Argumnet is null.");

            var item = GetByID(updatedItem.ID);

            if (item == null)
                throw new ArgumentException("Invalid Checkout ID.");

            item = updatedItem; // replace the old item

            return item;
        }

        public List<DisplayCheckOutItem> GetCheckOutItemsByID(int userId)
        {
            return CheckOutUtils.ProcessCheckOutItemsByID(userId);
        }

    }
}
