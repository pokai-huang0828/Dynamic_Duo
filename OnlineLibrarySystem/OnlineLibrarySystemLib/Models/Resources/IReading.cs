using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib
{
    public interface IReading : IResource
    {
         int NumberOfPages { get; set; }
         string Publisher { get; set; }
         DateTime PublicDate { get; set; }
         string Language { get; set; }
    }
}
