using ContactBook.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.API.Repository
{
    public class ContactRepository : IContactRepository
    {
        ContactDBContext _dbContext;

        public ContactRepository(ContactDBContext contactDBContext)
        {
            _dbContext = contactDBContext;
        }

        public Response AddUpdateContact(Contacts contact)
        {
            try
            {
                //Add New Contacts
                if (contact.Id == 0)
                {
                    Contacts newContact = new Contacts
                    {
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        Email = contact.Email,
                        Phone = contact.Phone,
                        Status = contact.Status,
                    };

                    _dbContext.Contacts.Add(newContact);
                    _dbContext.SaveChanges();

                    return new Response { Status = "Created", Message = "New contact added successfully" };
                }
                //Update Contacts
                else
                {
                    var curContact = _dbContext.Contacts.Where(x => x.Id == contact.Id).FirstOrDefault();

                    if (curContact != null && curContact.Id > 0)
                    {
                        curContact.FirstName = contact.FirstName;
                        curContact.LastName = contact.LastName;
                        curContact.Email = contact.Email;
                        curContact.Phone = contact.Phone;
                        curContact.Status = contact.Status;

                        _dbContext.SaveChanges();
                        return new Response { Status = "Updated", Message = "Contact updated successfully" };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new Response { Status = "Error", Message = "DB Insert/Update Error" };
        }

        public Response DeleteContact(int contactId)
        {
            var curContact = _dbContext.Contacts.Where(x => x.Id == contactId).FirstOrDefault();

            if (curContact != null)
            {
                _dbContext.Contacts.Remove(curContact);
                _dbContext.SaveChanges();

                return new Response { Status = "Deleted", Message = "Deleted Contact Successfully" };
            }

            return new Response { Status = "Error", Message = "DB Delete Error" };
        }

        public Contacts GetContact(int contactId)
        {
            var contact = _dbContext.Contacts.Where(x => x.Id == contactId).FirstOrDefault();
            return contact;
        }

        public List<Contacts> GetContacts()
        {
            var contacts = _dbContext.Contacts.ToList();
            return contacts;
        }
    }
}
