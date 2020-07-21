using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Web.Models
{
    public class PhoneBookEntries
    {
        public int PhoneBookId { get; set; }
        public string SearchTerm { get; set; }
        public PhoneBookVM PhoneBook { get; set; }
        public List<EntryVM> Entries { get; set; }
    }
}
