using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib.UnitsOfWork
{
    public class CheckOutUtils
    {        
        public static void ProcessCheckOut(CheckOut item)
        {
            var resourceRepository = new ResourceRepository();
            var resourceCount = new Dictionary<int, int>();

            var checkOutItemIds = item.ResourceIDs;
            checkOutItemIds.ForEach(id => {

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
        }

        public static void RemoveCheckOut(CheckOut checkout)
        {
            var resourceRepository = new ResourceRepository();

            checkout.ResourceIDs.ForEach(r_id =>
            {
                var resource = resourceRepository.GetByID(r_id);

                if (resource != null)
                    resourceRepository.IncrementResourceCopies(resource.ResourceID);
            });
        }

        public static List<DisplayCheckOutItem> ProcessCheckOutItemsByID(int userId)
        {
            var resourceRepository = new ResourceRepository();
            var checkOutRepository = new CheckOutRepository();
            var checkOutItems = new List<DisplayCheckOutItem>();

            checkOutRepository.GetAll()
                .Where(c => c.UserID == userId)
                .ToList()
                .ForEach(c =>
                {
                    foreach (var resourceId in c.ResourceIDs)
                    {
                        var resource = resourceRepository.GetByID(resourceId);

                        var displayCheckOutItem = new DisplayCheckOutItem(
                            resource.ResourceID, resource.Title,
                            c.CheckOutDate, c.DueDate);

                        checkOutItems.Add(displayCheckOutItem);
                    }
                });

            checkOutItems.Sort((c, d) => d.DueDate.CompareTo(c.DueDate));

            return checkOutItems;
        }

    }
}
