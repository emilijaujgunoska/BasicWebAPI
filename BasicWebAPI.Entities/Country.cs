using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Entities
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; } = null!;

        public ICollection<Contact>? Contacts { get; set; }
    }
}
