using Contacts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Services.IServices
{
    public interface IContactService
    {
        Task<IEnumerable<ContactsPage>> GetContact();
        Task AddContact(ContactsPage entity);
        Task DeleteContact(string mobilePhone);
        Task UpdateContact(string mobilePhone, ContactsPage newEntity);
    }
}
