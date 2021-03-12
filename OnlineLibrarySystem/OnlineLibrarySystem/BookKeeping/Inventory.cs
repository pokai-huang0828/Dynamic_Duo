using OnlineLibrarySystem.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineLibrarySystem
{
    public class Inventory : IEnumerable
    {
        private List<Resource> _listOfResource;
        private int _lastResourceID;

        public Inventory()
        {
            _listOfResource = new List<Resource>();
            _lastResourceID = 0;
        }

        public void AddToInventory(Resource r) 
        {
            r.ResourceID = ++_lastResourceID;
            _listOfResource.Add(r);
        }

        public void RemoveFromInventory(int resourceID) 
        {
            _listOfResource.RemoveAll(r => r.ResourceID == resourceID);
        }

        public void CheckOutResource(int resourceID) 
        {
            foreach(Resource r in _listOfResource)
            {
                if (r.ResourceID == resourceID && r.CopyInStock > 0)
                    r.CopyInStock-- ;
            }
        }
        
        public void ReturnResource(int resourceID) 
        {
            foreach (Resource r in _listOfResource)
            {
                if (r.ResourceID == resourceID && r.CopyInStock < r.TotelNumberOfCopies)
                    r.CopyInStock++;
            }
        }

        public bool IsResourceAvailable(int resourceID) 
        {
            Resource result= SearchResourceByID(resourceID);
            if(result != null)
                return result.CopyInStock > 0 ? true : false;
            return false;
        }

        public Resource SearchResourceByID(int resourceID) 
        { 
            return _listOfResource.FirstOrDefault(r => r.ResourceID == resourceID); 
        }

        public List<Resource> SearchResourceByCategory(string category) 
        {
            switch (category.ToLower())
            {
                case "reading":
                    return _listOfResource.Where(r => r is Reading).ToList();
                case "audio":
                    return _listOfResource.Where(r => r is Audio).ToList();
                case "video":
                    return _listOfResource.Where(r => r is Video).ToList();
                default:
                    return default(List<Resource>);
            }
        }

        public List<Resource> SearchResourceByTitle(string title) { 
            return _listOfResource.Where( r=> r.Title == title).ToList(); 
        }

        public IEnumerator GetEnumerator()
        {
            foreach(Resource r in _listOfResource)
            {
                yield return r;
            }
        }
    }
}
