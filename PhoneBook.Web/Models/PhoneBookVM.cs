using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PhoneBook.Domain.Entities;

namespace PhoneBook.Web.Models
{
    public class PhoneBookVM //: Domain.Entities.PhoneBook
    {
        public PhoneBookVM PhoneBookVMObj(Domain.Entities.PhoneBook phoneBook)
        {
            if(phoneBook!=null)
            return new PhoneBookVM
            {
                Id = phoneBook.Id,
                Name = phoneBook.Name,
                //Entries = phoneBook.Entries
            };

            return new PhoneBookVM();
        }

        public Domain.Entities.PhoneBook PhoneBookObj(PhoneBookVM phoneBook)
        {
            if(phoneBook!=null)
            return new Domain.Entities.PhoneBook
            {
                Id = phoneBook.Id,
                Name = phoneBook.Name,
                Entries = phoneBook.Entries
            };

            return null; //new Domain.Entities.PhoneBook();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Entry> Entries { get; set; }
    }
}
