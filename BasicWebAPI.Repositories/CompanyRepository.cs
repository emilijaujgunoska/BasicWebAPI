using BasicWebAPI.Data;
using BasicWebAPI.Entities;
using BasicWebAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly BasicWebApiDbContext _context;

        public CompanyRepository(BasicWebApiDbContext context)
        {
            _context = context;
        }

        public void Create(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public void Delete(Company company)
        {
            _context.Companies.Remove(company);
            _context.SaveChanges();
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            var result = _context.Companies.AsEnumerable();
            return result;
        }

        public void Update(Company company)
        {
            _context.Companies.Update(company);
            _context.SaveChanges();
        }
        public Company GetCompanyById(int companyId)
        {
            var result = _context.Companies.FirstOrDefault(c => c.CompanyId == companyId);
            return result;
        }

        Company ICompanyRepository.GetCompanyById(int companyId)
        {
            throw new NotImplementedException();
        }
    }
}
