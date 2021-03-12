using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystem.Resources
{
    public class Videogame : Video
    {
        public int YearOfPublish { get; set; }

        public Videogame(int t)
        {
            TotelNumberOfCopies = t;
            CopyInStock = t;
        }

    }
}
