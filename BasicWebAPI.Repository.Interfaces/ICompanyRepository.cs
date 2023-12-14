using BasicWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Repository.Interfaces
{
    public interface ICompanyRepository
    {
        void Create(Company company);
        void Update(Company company);
        void Delete(Company company);

       Company GetCompanyById(int companyId);

        IEnumerable<Company> GetAllCompanies();
    }
}
