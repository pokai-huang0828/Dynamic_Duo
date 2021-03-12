using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystem.Resources
{
    public abstract class Audio : Resource
    {
        public int TrackNumber { get; set; }
        public float Duration { get; set; }
        public string Producer { get; set; }
    }
}
