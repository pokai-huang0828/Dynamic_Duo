using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib
{
    public class Address
    {
        public string Street { get; set; }
        public string Unit { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public override string ToString() 
        {
            return String.Format("{0} {1} {2} {3} {4} {5}",
                         Unit,
                         Street,
                         City,
                         Province,
                         Country,
                         PostalCode);
        }

    }
}
