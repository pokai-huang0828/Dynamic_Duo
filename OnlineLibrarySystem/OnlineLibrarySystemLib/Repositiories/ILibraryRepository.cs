using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib
{
    interface ILibraryRespository<T>
    {
        int Add(T item);

        void RemoveByID(int id);

        T Update(int id, T updatedItem);

        T GetByID(int id);

        IEnumerable<T> GetAll();

    }
}
