using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystem.Resources
{
    public class DVD : Video
    {
        public string Length { get; set; }
        public string Language { get; set; }

        public DVD(int t)
        {
            TotelNumberOfCopies = t;
            CopyInStock = t;
        }
    }
}
