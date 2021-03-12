using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystem.Resources
{
    public class Magazine : Reading
    {
        public int IssueNumber { get; set; }
        public string Subject { get; set; }

        public Magazine(int t)
        {
            TotelNumberOfCopies = t;
            CopyInStock = t;
        }
    }
}
