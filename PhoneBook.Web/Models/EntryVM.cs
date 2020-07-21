using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PhoneBook.Domain.Entities;

namespace PhoneBook.Web.Models
{
    public class EntryVM //: Entry
    {
        public EntryVM EntryVMObj(Entry entry)
        {
            if(entry!=null)
            return new EntryVM
            {
                Id = entry.Id,
                Name = entry.Name,
                PhoneBook = new PhoneBookVM().PhoneBookVMObj(entry.PhoneBook),
                PhoneBookId = entry.PhoneBookId,
                PhoneNumber = entry.PhoneNumber
            };

            return new EntryVM();
        }

        public Entry EntryObj(EntryVM entry)
        {
            if (entry != null)
                return new Entry
                {
                    Id = entry.Id,
                    Name = entry.Name,
                    PhoneBook = new PhoneBookVM().PhoneBookObj(entry.PhoneBook),
                    PhoneBookId = entry.PhoneBookId,
                    PhoneNumber = entry.PhoneNumber
                };

            return null; //new Entry();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneBookId { get; set; }
        public PhoneBookVM PhoneBook { get; set; }
    }
}
