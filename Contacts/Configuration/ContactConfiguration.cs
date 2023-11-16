using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Configuration
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> modelBuilder)
        {
            modelBuilder.HasKey(c => c.ContactId);
            modelBuilder.Property(c => c.ContactId).HasDefaultValueSql("newid()");
            modelBuilder.Property(c => c.Name).HasMaxLength(255);
            modelBuilder.Property(c => c.MobilePhone).HasMaxLength(255);
            modelBuilder.Property(c => c.JobTitle).HasMaxLength(255);
            modelBuilder.HasIndex(c => c.MobilePhone).IsUnique();
        }
    }
}