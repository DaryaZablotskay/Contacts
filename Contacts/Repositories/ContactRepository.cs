using Microsoft.EntityFrameworkCore;
using Contacts.Models;
using Contacts.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactContext _contactContext;

        public ContactRepository(ContactContext contactContext)
        {
            _contactContext = contactContext;
        }

        public IQueryable<Contact> GetAll()
        {
            return _contactContext.Contacts.AsQueryable();
        }

        public Task Add(Contact contact)
        {
            return _contactContext.Contacts.AddAsync(contact).AsTask();
        }

        public Task Save()
        {
            return _contactContext.SaveChangesAsync();
        }

        public void Update(Contact contact)
        {
            _contactContext.Entry(contact).State = EntityState.Modified;
        }
    }
}
