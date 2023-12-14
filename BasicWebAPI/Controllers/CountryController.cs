using BasicWebAPI.Entities;
using BasicWebAPI.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebAPI.Controllers
{
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController( ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost("Country")]
        public ActionResult CreateCountry([FromBody] Country country)
        {
            _countryService.Create(country);
            return Ok(country);
        }
        [HttpDelete("DeleteCountry")]
        public ActionResult<Country> DeleteCountry(int countryId)
        {
            try
            {
                var getCountryById = _countryService.GetCountryById(countryId);

                if (countryId == null) { return StatusCode(StatusCodes.Status404NotFound); }
                _countryService.Delete(getCountryById);
            }
            catch (Exception ex) { return StatusCode(500, "Internal server error"); }
            return Ok();
        }
        [HttpPost("UpdateCountry")]
        public ActionResult<Country> UpdateCompany([FromBody] Country country)
        {
            try
            {

                var contactToUpdate = _countryService.GetCountryById(country.CountryId);

                if (contactToUpdate == null) { return StatusCode(StatusCodes.Status404NotFound); }
                _countryService.Update(contactToUpdate);
                return StatusCode(StatusCodes.Status202Accepted, country);

            }

            catch (Exception ex) { return StatusCode(500, "Internal server error"); }
        }

    }
}
