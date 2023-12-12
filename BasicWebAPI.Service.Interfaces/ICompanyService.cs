
using BasicWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Service.Interfaces
{
    public interface ICompanyService
    {
        void Create(Company company);
        void Update(Company company);
        void Delete(Company company);

        IEnumerable<Company> GetAllCompanies();

    }
}
