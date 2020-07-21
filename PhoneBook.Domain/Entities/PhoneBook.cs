using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace PhoneBook.Domain.Entities
{
    public class PhoneBook
    {
        public PhoneBook()
        {
            this.Entries = new HashSet<Entry>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Entry> Entries { get; set; }
    }
}
