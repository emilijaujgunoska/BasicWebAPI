using BasicWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Repository.Interfaces
{
    public interface ICountryRepository
    {
        void Create(Country country);

        void Update(Country country);

        void Delete(Country country);

        IEnumerable<Country> GetAllCountries();
    }
}
