using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystem.Resources
{
    public class CD : Audio
    {
        public string Artist { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public string Length { get; set; }
    }
}
