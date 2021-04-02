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
        private ResourceRepository resourceRepository;
        
        public ResourceSearch()
        {
            resourceRepository = new ResourceRepository();
        }
        
        public IEnumerable<IResource> FindByCategory(ResourceType resourceType)
        {
            return resourceRepository.GetResourceByResourceType(resourceType);
        }

        public IEnumerable<IResource> FindByName(string name)
        {
            return resourceRepository.GetResourceByName(name);
        }

        public IEnumerable<IResource> SearchRespository (
            string keyword, string category, string searchType )
        {
            var results = new List<IResource>();

            switch (searchType)
            {
                case "name":
                    results = FindByName(keyword).ToList();
                    break;

                case "resourceId":
                    int number;
                    if (!Int32.TryParse(keyword, out number))
                        break;

                    var result = resourceRepository.GetByID(number);
                    if (result != null)
                        results.Add(result);
                    break;

                default:
                    results = resourceRepository.GetAll().ToList();
                    break;
            }

            if(searchType == "author" &&  keyword != "")
            {
                results = results.Where(r => r is Book &&
                ((Book)r).Author != null &&
                ((Book)r).Author.ToLower()
                .Contains(keyword.ToLower())).ToList();
            }

            // Filter resources by category
            switch (category)
            {
                case "reading":
                    results = results.Where(r => r is IReading).ToList();
                    break;
                case "audio":
                    results = results.Where(r => r is IAudio).ToList();
                    break;
                case "video":
                    results = results.Where(r => r is IVideo).ToList();
                    break;
            }

            return results;
        }
    }
}
