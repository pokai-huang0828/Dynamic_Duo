using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib 
{
    public interface IVideo : IResource
    {
         int TrackNumber { get; set; }
         float Duration { get; set; }
         string Producer { get; set; }
         string Genre { get; set; }
    }
}
