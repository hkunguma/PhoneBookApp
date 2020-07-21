using System;
using System.Collections.Generic;
using System.Text;

using PhoneBook.Domain.Entities;

namespace PhoneBook.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Domain.Entities.PhoneBook> PhoneBookRepository { get; }
        IGenericRepository<Entry> EntryRepository { get; }
        void Save();
        void Dispose();
        //void Dispose(bool disposing);
    }
}
