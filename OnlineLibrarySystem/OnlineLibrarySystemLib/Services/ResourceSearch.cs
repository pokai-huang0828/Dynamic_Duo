using OnlineLibrarySystemLib.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib.Services
{
    public class ResourceSearch: IBasicSearch<IResource, ResourceType>
    {
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
    }
}
