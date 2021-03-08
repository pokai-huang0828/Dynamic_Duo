using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystem
{
    public abstract class Resource
    {
        public string ResourceID { get; set; }
        public string Title { get; set; }
        public string CopyInStock { get; set; }
        public string TotelNumberOfCopies { get; set; }
    }
}
