using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystem.Resources
{
    public class Book : Reading
    {
        public string Author { get; set; }
        public int YearOfPublish { get; set; }
        public string Genre { get; set; }
    }
}
