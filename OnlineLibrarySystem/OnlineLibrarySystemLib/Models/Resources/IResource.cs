using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib 
{ 
    public interface IResource
    {
        int ResourceID { get; set; }
        string Title { get; set; }
        int CopyInStock { get; set; }
        int TotelNumberOfCopies { get; set; }
    }
}
