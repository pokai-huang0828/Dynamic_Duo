using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib
{
    public class Videogame : IVideo
    {
        public int YearOfPublish { get; set; }
        public int TrackNumber { get; set; }
        public float Duration { get; set; }
        public int Producer { get; set; }
        public string Genre { get; set; }
        public int ResourceID { get; set; }
        public string Title { get; set; }
        public int CopyInStock { get; set; }
        public int TotalNumberOfCopies { get; set; }

        public Videogame(string title, int totalNumberOfCopies)
        {
            InitializeResource(title, totalNumberOfCopies);
        }

        public void InitializeResource(string title, int totalNumberOfCopies)
        {
            Title = title;
            TotalNumberOfCopies = CopyInStock = totalNumberOfCopies;
        }

    }
}
