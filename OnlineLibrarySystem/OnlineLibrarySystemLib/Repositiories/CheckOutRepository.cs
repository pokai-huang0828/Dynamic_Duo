using OnlineLibrarySystemLib.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib
{
    public class CheckOutRepository : ILibraryRespository<CheckOut>
    {
        public int Add(CheckOut item)
        {
            var checkOutItemIds = item.ResourceIDs;
            var resourceRepository = new ResourceRepository();

            var resourceCount = new Dictionary<int, int>();

            checkOutItemIds.ForEach( id => {

                var resource = resourceRepository.GetByID(id);

                if (resource == null)
                    new ArgumentException($"No resource with id: {id}.");

                if (resource.CopyInStock == 0)
                    throw new ArgumentException($"{resource.Title} is out of stock. Please try again.");

                resourceCount[id] = resourceCount.ContainsKey(id) ? ++resourceCount[id] : 1;
          
            });

            var OutOfStockItem = resourceCount.FirstOrDefault(pair =>
            {
                var resource = resourceRepository.GetByID(pair.Key);
                return resource.CopyInStock < pair.Value;
            });

            if (!OutOfStockItem.Equals(null) && OutOfStockItem.Value != 0)
            {
                var resource = resourceRepository.GetByID(OutOfStockItem.Key);
                throw new ArgumentException($"{resource.Title} is not available. Please try again.");
            }

            checkOutItemIds.ForEach(id =>
            resourceRepository.DecrementResourceCopies(id));
            
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
            // Increment Resource Copies
            var checkout = GetByID(id);
            
            if (checkout == null)
                return;

            var resourceRepository = new ResourceRepository();

            checkout.ResourceIDs.ForEach(r_id =>
           {
               var resource = resourceRepository.GetByID(r_id);

               if (resource != null)
                   resourceRepository.IncrementResourceCopies(resource.ResourceID);
           });
            
            CheckOutData.CheckOutList.RemoveAll(c => c.ID == id);
        }

        public CheckOut Update(CheckOut updatedItem)
        {
            if (updatedItem == null)
                throw new ArgumentException("Argumnet is null.");

            var item = GetByID(updatedItem.ID);

            if (item == null)
                throw new ArgumentException("Invalid Checkout ID.");

            item = updatedItem;

            return item;
        }
    }
}
