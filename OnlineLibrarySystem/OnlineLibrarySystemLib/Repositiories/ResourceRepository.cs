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

        public void DecrementResourceCopies(int id)
        {
            var resource = GetByID(id);

            if(resource.CopyInStock > 0)
                resource.CopyInStock--;
        }
        
        public void IncrementResourceCopies(int id)
        {
            var resource = GetByID(id);

            if(resource.TotalNumberOfCopies != resource.CopyInStock)
                resource.CopyInStock++;
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

        public int GetResourceCopiesByID(int resourceId)
        {
            var resource = GetByID(resourceId);

            if (resource == null)
                throw new ArgumentException("No resource with this id");

            return resource.CopyInStock;
        }

        public IEnumerable<IResource> GetResourceByResourceType(ResourceType resourceType)
        {
            switch (resourceType)
            {
                case ResourceType.Reading:
                    return ResourceData.ResourceList.Where(r => r is IReading).ToList();
                case ResourceType.Audio:
                    return ResourceData.ResourceList.Where(r => r is IAudio).ToList();
                case ResourceType.Video:
                    return ResourceData.ResourceList.Where(r => r is IVideo).ToList();
                default:
                    return null;
            }
        }

        public IEnumerable<IResource> GetResourceByName(string name)
        {
            return ResourceData.ResourceList
                .Where(u => u.Title.ToLower().Contains(name.ToLower())).ToList();
        }

    }
}
