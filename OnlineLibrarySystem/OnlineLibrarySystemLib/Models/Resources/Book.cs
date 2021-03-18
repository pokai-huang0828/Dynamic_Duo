using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib
{
    public class Book : IReading
    {
        public string Author { get; set; }
        public int YearOfPublish { get; set; }
        public string Genre { get; set; }
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; }
        public DateTime PublicDate { get; set; }
        public string Language { get; set; }
        public int ResourceID { get; set; }
        public string Title { get; set; }
        public int CopyInStock { get; set; }
        public int TotelNumberOfCopies { get; set; }
    }
}
