using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib.Models.Data
{
    public class ResourceData
    {
        private static List<IResource> _list;
        private static int _lastID;

        private ResourceData() { }

        public static List<IResource> ResourceList
        {
            get
            {
                if (_list == null)
                {
                    _list = GetResources();
                    _lastID = _list.Count;
                }
                return _list;
            }
        }

        public static int LastID => _lastID;

        public static void IncrementLastID()
        {
            ++_lastID;
        }

        private static List<IResource> GetResources()
        {
            return new List<IResource>
            {
                new Book ("Harry Potter 1", 6){ ResourceID = 1 },
                new Book ("Harry Potter 6", 0){ ResourceID = 2 },
                new Book ("Lord of the Rings", 6){ ResourceID = 3 },
                new Magazine("Glamour", 4){ ResourceID = 4 },
                new Magazine("QC", 4){ ResourceID = 5 },
                new CD("folklore", 3){ ResourceID = 6 },
                new CD("Hot Pink", 2){ ResourceID = 7 },
                new DVD("Mad Max", 2){ ResourceID = 8 },
                new DVD("X-MEN", 3){ ResourceID = 9 },
                new Bluray("Tron Legacy", 2){ ResourceID = 10 },
                new Bluray("Pacific Rim Uprising",3){ ResourceID = 11 },
                new Videogame("Gear of War", 3){ ResourceID = 12 },
                new Videogame("Call of Duty", 4){ ResourceID = 13 }
            };
        }



    }
}
