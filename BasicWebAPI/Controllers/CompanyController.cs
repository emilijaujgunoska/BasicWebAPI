using BasicWebAPI.Entities;
using BasicWebAPI.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebAPI.Controllers
{
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("Company")]
        public ActionResult CreateCompany([FromBody] Company company)
        {
            _companyService.Create(company);
            return Ok(company);
        }

        [HttpDelete("DeleteCompany")]
        public ActionResult<Contact> DeleteCompany(int companyId)
        {
            try
            {
                var getCompanyById = _companyService.GetCompanyById(companyId);

                if (companyId == null) { return StatusCode(StatusCodes.Status404NotFound); }
                _companyService.Delete(getCompanyById);
            }
            catch (Exception ex) { return StatusCode(500, "Internal server error"); }
            return Ok();
        }

        [HttpPost("UpdateCompany")]
        public ActionResult<Contact> UpdateCompany([FromBody] Company company)
        {
            try
            {

                var contactToUpdate = _companyService.GetCompanyById(company.CompanyId);

                if (contactToUpdate == null) { return StatusCode(StatusCodes.Status404NotFound); }
                _companyService.Update(contactToUpdate);
                return StatusCode(StatusCodes.Status202Accepted, company);

            }

            catch (Exception ex) { return StatusCode(500, "Internal server error"); }
        }

    }
}
