using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using PhoneBook.Domain.Entities;

namespace PhoneBook.Domain.Interfaces
{
    public interface IPhoneBookApiClient
    {
        #region //phonebook

        Task<List<Entities.PhoneBook>> GetPhoneBooks();

        Task<Entities.PhoneBook> GetPhoneBookById(int id);

        Task CreatePhoneBook(Domain.Entities.PhoneBook phoneBook);

        #endregion //phonebook

        #region //entry

        Task<List<Entry>> GetEntries(int phoneBookId, string nameSearchTerm = null);

        Task<Entry> GetEntryById(int id);

        Task CreateEntry(Entry entry);

        #endregion //entry
    }
}
