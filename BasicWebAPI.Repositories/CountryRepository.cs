using BasicWebAPI.Entities;
using BasicWebAPI.Repository.Interfaces;
using BasicWebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly BasicWebApiDbContext _context;

        public CountryRepository(BasicWebApiDbContext context)
        {
            _context = context;
        }

        public void Create(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
        }

        public void Delete(Country country)
        {
            _context.Countries.Remove(country);
            _context.SaveChanges();
        }

        public IEnumerable<Country> GetAllCountries()
        {
            var result = _context.Countries.AsEnumerable();
            return result;
        }

        public void Update(Country country)
        {
            _context.Countries.Update(country);
            _context.SaveChanges();
        }
    }
}
