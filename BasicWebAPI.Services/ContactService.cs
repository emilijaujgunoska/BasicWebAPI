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

    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void Create(Contact contact)
        {
            _contactRepository.Create(contact);
        }

        public void Delete(Contact contact)
        {
            _contactRepository.Delete(contact);
        }

        public IEnumerable<Contact> FilterContacts(int countryId, int companyId)
        {
            var result = _contactRepository.FilterContacts(countryId, companyId);
            return result;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            var result = _contactRepository.GetAllContacts();
            return result;
        }

        public IEnumerable<Contact> GetContactsWithCompanyAndCountry(string companyName, string countryName)
        {
            var result = _contactRepository.GetContactsWithCompanyAndCountry(companyName, countryName);
            return result;
        }

        public void Update(Contact contact)
        {
            _contactRepository.Update(contact);
        }
    }
}
