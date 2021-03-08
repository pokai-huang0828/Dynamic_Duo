using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystem
{
    public abstract class Reading : Resource
    {
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; }
        public DateTime PublicDate { get; set; }
        public string Language { get; set; }
    }
}
