using BasicWebAPI.Entities;
using BasicWebAPI.Repository.Interfaces;
using BasicWebAPI.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public void Create(Country country)
        {
            _countryRepository.Create(country);
        }

        public void Delete(Country country)
        {
            _countryRepository.Delete(country);
        }

        public IEnumerable<Country> GetAllCountries()
        {
           var result = _countryRepository.GetAllCountries();
            return result;

        }

        public Country GetCountryById(int countryId)
        {
           var result = _countryRepository.GetCountryById(countryId);
            return result;
        }

        public void Update(Country country)
        {
            _countryRepository.Update(country);
        }
    }
}
