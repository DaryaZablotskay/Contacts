using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Repositories.Interfaces
{
    public interface IContactRepository
    {
        IQueryable<Contact> GetAll();
        Task Add(Contact contact);
        void Update(Contact contact);
        Task Save();
    }
}
