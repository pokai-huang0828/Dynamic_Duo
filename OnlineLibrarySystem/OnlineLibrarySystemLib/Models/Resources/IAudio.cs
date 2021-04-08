using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib
{
    public interface IAudio : IResource
    {
        int TrackNumber { get; set; }
        float DurationInMins { get; set; }
        string Producer { get; set; }

    }
}
