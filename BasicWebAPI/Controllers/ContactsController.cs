using BasicWebAPI.Entities;
using BasicWebAPI.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebAPI.Controllers
{
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpPost("Contact")]
        public ActionResult CreateContact([FromBody] Contact contact)
        {
            _contactService.Create(contact);
            return Ok(contact);
        }

        [HttpDelete("DeleteContact")]
        public ActionResult<Contact> DeleteContact(int ContactId)
        {
            try
            {
               var getContactById= _contactService.GetContactById(ContactId);

                if (ContactId == null) { return StatusCode(StatusCodes.Status404NotFound); }
                _contactService.Delete(getContactById);
            }
            catch (Exception ex) { return StatusCode(500, "Internal server error"); }
            return Ok();
        }

        [HttpPost("UpdateContact")]
        public ActionResult<Contact> UpdateContact([FromBody] Contact contact)
        {
            try {

                var contactToUpdate = _contactService.GetContactById(contact.ContactId);

                if (contactToUpdate == null) { return StatusCode(StatusCodes.Status404NotFound); }
                _contactService.Update(contactToUpdate);
                return StatusCode(StatusCodes.Status202Accepted,contact);
            
            }

            catch(Exception ex) { return StatusCode(500, "Internal server error"); }
        }

        [HttpGet("FilterContacts")]
        public ActionResult<IEnumerable<Contact>> FilterContacts(int countryId, int companyId)
        {
            try { 
            var FilterContacts = _contactService.FilterContacts(countryId, companyId);
            if(FilterContacts == null) { return StatusCode(StatusCodes.Status404NotFound); }

            return  Ok(FilterContacts);
            }

            catch(Exception ex) { return StatusCode(500, "Internal server error"); }

        }

        [HttpGet("GetContactsWithCompanyAndCountry")]
        public ActionResult< IEnumerable<Contact>> GetContactsWithCompanyAndCountry(string companyName, string countryName)
        {
            try
            {
                var Contacts = _contactService.GetContactsWithCompanyAndCountry( companyName, countryName);
                if (Contacts == null) { return StatusCode(StatusCodes.Status404NotFound); }

                return Ok(Contacts);
            }

            catch (Exception ex) { return StatusCode(500, "Internal server error"); }

        }

    }
}
