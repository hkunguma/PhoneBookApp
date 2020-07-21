using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace PhoneBook.Domain.Entities
{
    public class Entry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneBookId { get; set; }
        public virtual PhoneBook PhoneBook { get; set; }
    }
}
