using System;
using Contacts.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Helpers
{
    public static class SeedData
    {
        public static Contact[] GenerateContacts()
        {
            var contact = new Contact[]
            {
                new Contact
                {
                    ContactId = Guid.NewGuid(),
                    Name = "Dasha",
                    MobilePhone = "+375 29 873 17 77",
                    JobTitle = "Student",
                    BirthDate = new DateTime(2003, 5, 14)
                },
                new Contact
                {
                    ContactId = Guid.NewGuid(),
                    Name = "Dima",
                    MobilePhone = "+375(29) 463-76-13",
                    JobTitle = "Teacher",
                    BirthDate = new DateTime(2003, 6, 6)
                },
                new Contact
                {
                    ContactId = Guid.NewGuid(),
                    Name = "Ksusha",
                    MobilePhone = "+375(29)3178954",
                    JobTitle = "Dancer",
                    BirthDate = new DateTime(2003, 7, 7)
                }
            };
            return contact;
        }
    }
}
