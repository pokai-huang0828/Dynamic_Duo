using OnlineLibrarySystemLib.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib
{
    public class ResourceRepository : ILibraryRespository<IResource>
    {
        public int Add(IResource item)
        {
            if (ResourceData.ResourceList
                .Exists(r => r.Title == item.Title 
                && item.GetType() == r.GetType()) )
                throw new ArgumentException("Resource already existed.");

            ResourceData.IncrementLastID();
            item.ResourceID = ResourceData.LastID;
            ResourceData.ResourceList.Add(item);

            return item.ResourceID;
        }

        public IResource GetByID(int id)
        {
            return ResourceData.ResourceList.FirstOrDefault(r => r.ResourceID == id);
        }

        public void RemoveByID(int id)
        {
            ResourceData.ResourceList.RemoveAll(r => r.ResourceID == id);
        }

        public IResource Update(IResource updatedResource)
        {
            if (updatedResource == null)
                throw new ArgumentException("Updated User is null.");

            var resource = GetByID(updatedResource.ResourceID);

            if (resource == null)
                throw new ArgumentException("Invalid Resource Id.");

            var oldResource = ResourceData.ResourceList
                .Find(r => r.ResourceID == updatedResource.ResourceID);

            oldResource = updatedResource;

            return updatedResource;
        }

        public IEnumerable<IResource> GetAll()
        {
            return ResourceData.ResourceList.ToList();
        }
    }
}
