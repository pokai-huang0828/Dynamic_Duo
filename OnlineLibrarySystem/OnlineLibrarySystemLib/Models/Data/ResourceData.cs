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
                new Book ("Harry Potter", 5),
                new Book ("Lord of the Rings", 6),
                new Magazine("Glamour", 4),
                new Magazine("QC", 4),
                new CD("folklore", 3),
                new CD("Hot Pink", 2),
                new DVD("Mad Max", 2),
                new DVD("X-MEN", 3),
                new Bluray("Tron Legacy", 2),
                new Bluray("Pacific Rim Uprising",3),
                new Videogame("Gear of War", 3),
                new Videogame("Call of Duty", 4)
            };
        }



    }
}
