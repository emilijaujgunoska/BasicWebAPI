using BasicWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Service.Interfaces
{
    public interface IContactService
    {
        void Create(Contact contact);

        void Update(Contact contact);

        void Delete(Contact contact);

        public Contact GetContactById(int contactId);

        IEnumerable<Contact> GetContactsWithCompanyAndCountry(string companyName, string countryName);

        IEnumerable<Contact> GetAllContacts();

        IEnumerable<Contact> FilterContacts(int countryId, int companyId);
    }
}
