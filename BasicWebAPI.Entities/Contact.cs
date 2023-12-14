using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }


        public string ContactName { get; set; } = null!;

        public int CompanyId { get; set; } 

        public string CompanyName { get; set; }

        public Company? Company { get; set; }

        public int CountryId { get; set;}

        public string CountryName { get; set; }

        public Country? Country { get; set; }
    }
}
