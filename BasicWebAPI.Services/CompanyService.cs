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
    public class CompanyService : ICompanyService
    {

        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public void Create(Company company)
        {
           _companyRepository.Create(company);
        }

        public void Delete(Company company)
        {
            _companyRepository.Delete(company);
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            var result = _companyRepository.GetAllCompanies();
            return result;
        }

        public void Update(Company company)
        {
            _companyRepository.Update(company);
        }
    }
}
