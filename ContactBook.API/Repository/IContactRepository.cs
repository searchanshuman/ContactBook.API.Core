using ContactBook.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.API.Repository
{
    public interface IContactRepository
    {
        List<Contacts> GetContacts();

        Contacts GetContact(int contactId);

        Response AddUpdateContact(Contacts contact);

        Response DeleteContact(int contactId);
    }
}
