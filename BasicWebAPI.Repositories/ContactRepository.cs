using BasicWebAPI.Data;
using BasicWebAPI.Entities;
using BasicWebAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly BasicWebApiDbContext _context;

        public ContactRepository(BasicWebApiDbContext context)
        {
            _context = context;
        }
        public void Create(Contact contact)
        {
          _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void Delete(Contact contact)
        {
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }

        public IEnumerable<Contact> FilterContacts(int countryId, int companyId)
        {
            return _context.Contacts
                .Where(c=> c.CountryId == countryId && c.CompanyId == companyId).ToList();
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            var result = _context.Contacts.AsEnumerable();
            return result;
        }

        public IEnumerable<Contact> GetContactsWithCompanyAndCountry(string companyName, string countryName)
        {
            return _context.Contacts
             .Where(b => b.CompanyName == companyName && b.CountryName == countryName).ToList();
        }

        public void Update(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();
        }

        IEnumerable<Contact> IContactRepository.GetContactsWithCompanyAndCountry(string companyName, string countryName)
        {
            throw new NotImplementedException();
        }
    }
}
