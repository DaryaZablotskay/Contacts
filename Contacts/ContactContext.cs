using Microsoft.EntityFrameworkCore;
using Contacts.Models;
using Contacts.Configuration;
using Contacts.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ContactContext(DbContextOptions<ContactContext> context) : base(context)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            var contact = SeedData.GenerateContacts();
            modelBuilder.Entity<Contact>().HasData(contact);
        }
    }
}
