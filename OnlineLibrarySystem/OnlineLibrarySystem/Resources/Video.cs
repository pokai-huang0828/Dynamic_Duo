using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystem.Resources
{
    public abstract class Video : Resource
    {
        public int TrackNumber { get; set; }
        public float Duration { get; set; }
        public int Producer { get; set; }
        public string Genre { get; set; }
    }
}
