using Microsoft.EntityFrameworkCore;
using Contacts.Models;
using Contacts.Dto;
using Contacts.Repositories.Interfaces;
using Contacts.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactContext _contactContext;
        private readonly IContactRepository _contactRepository;

        public ContactService(ContactContext contactContext, IContactRepository contactRepository)
        {
            _contactContext = contactContext;
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<ContactsPage>> GetContact()
        {
            var contactAll = await (from contact in _contactContext.Contacts
                                      select new ContactsPage
                                      {
                                          Name = contact.Name,
                                          MobilePhone = contact.MobilePhone,
                                          JobTitle = contact.JobTitle,
                                          BirthDate = contact.BirthDate
                                      }).ToListAsync();
            return contactAll;
        }

        public async Task AddContact(ContactsPage entity)
        {
            var newContact = new Contact
            {
                Name = entity.Name,
                MobilePhone = entity.MobilePhone,
                JobTitle = entity.JobTitle,
                BirthDate = entity.BirthDate
            };
            await _contactRepository.Add(newContact);
            await _contactRepository.Save();
        }

        public async Task DeleteContact(string mobilePhone)
        {
            var existContact = await _contactRepository.GetAll().SingleOrDefaultAsync(f => f.MobilePhone == mobilePhone);
            _contactContext.Contacts.Remove(existContact);
            await _contactRepository.Save();

        }

        public async Task UpdateContact(string mobilePhone, ContactsPage newEntity)
        {
            var existContact = await _contactRepository.GetAll().SingleOrDefaultAsync(f => f.MobilePhone == mobilePhone);

            existContact.Name = newEntity.Name;
            existContact.MobilePhone = newEntity.MobilePhone;
            existContact.JobTitle = newEntity.JobTitle;
            existContact.BirthDate = newEntity.BirthDate;

            _contactRepository.Update(existContact);
            await _contactRepository.Save();
        }
    }
}
