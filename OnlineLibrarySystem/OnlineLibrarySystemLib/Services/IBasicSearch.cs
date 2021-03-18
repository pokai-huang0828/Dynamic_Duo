using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib
{
    interface IBasicSearch<T, ItemType>
    {
        IEnumerable<T> FindByName(string name);

        IEnumerable<T> FindByCategory(ItemType itemType);
    }
}
