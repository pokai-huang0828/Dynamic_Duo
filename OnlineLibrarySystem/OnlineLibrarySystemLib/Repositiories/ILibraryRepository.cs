using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib
{
    public interface ILibraryRespository<T>
    {
        int  Add(T item);

        void RemoveByID(int id);

        T Update(T updatedItem);

        T GetByID(int id);

        IEnumerable<T> GetAll();

    }
}
