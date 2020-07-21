using System;
using System.Collections.Generic;
using System.Text;

using PhoneBook.DAL.EF.Provider;
using PhoneBook.Domain.Interfaces;
using PhoneBook.Domain.Entities;

namespace PhoneBook.DAL.EF.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private PhoneBookContext context;
        private IGenericRepository<Domain.Entities.PhoneBook> phoneBookRepository;
        private IGenericRepository<Entry> entryRepository;

        public UnitOfWork(PhoneBookContext _context)
        {
            this.context = _context;
        }

        public IGenericRepository<Domain.Entities.PhoneBook> PhoneBookRepository
        {
            get
            {
                if(this.phoneBookRepository==null)
                {
                    this.phoneBookRepository = new GenericRepository<Domain.Entities.PhoneBook>(context);
                }

                return phoneBookRepository;
            }
        }

        public IGenericRepository<Entry> EntryRepository
        {
            get
            {
                if (this.entryRepository == null)
                {
                    this.entryRepository = new GenericRepository<Entry>(context);
                }

                return entryRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

    }
}
