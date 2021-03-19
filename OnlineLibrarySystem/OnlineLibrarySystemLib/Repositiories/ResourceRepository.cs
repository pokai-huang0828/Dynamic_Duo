using OnlineLibrarySystemLib.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib
{
    public class ResourceRepository : ILibraryRespository<IResource>, IBasicSearch<IResource, ResourceType>
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

            resource = updatedResource;

            return updatedResource;
        }

        public IEnumerable<IResource> FindByCategory(ResourceType resourceType)
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

        public IEnumerable<IResource> FindByName(string name)
        {
            return ResourceData.ResourceList.Where(u => u.Title == name).ToList();
        }

        public IEnumerable<IResource> GetAll()
        {
            return ResourceData.ResourceList.ToList();
        }
    }
}
