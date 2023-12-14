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
            
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            var result = _context.Contacts.AsEnumerable();
            return result;
        }

        public Contact GetContactsWithCompanyAndCountry(string companyName, string countryName)
        {
            throw new NotImplementedException();
        }

        public void Update(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();
        }
    }
}
