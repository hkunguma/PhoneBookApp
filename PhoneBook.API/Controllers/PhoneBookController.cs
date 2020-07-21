using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PhoneBook.DAL.EF.Provider;
using PhoneBook.DAL.EF.Repository;
using PhoneBook.Domain.Entities;
using PhoneBook.Domain.Interfaces;

namespace PhoneBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private IGenericRepository<Entry> entryRepository;
        private IUnitOfWork unitOfWork;

        public PhoneBookController(PhoneBookContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        #region //phonebook

        [HttpGet("getPhoneBooks")]
        public async Task<List<Domain.Entities.PhoneBook>> GetPhoneBooks()
        {
            return await Task.Run(() => unitOfWork.PhoneBookRepository.Get().ToList());
        }

        [HttpGet("getPhoneBookById")]
        public async Task<Domain.Entities.PhoneBook> GetPhoneBookById(int id)
        {
            return await Task.Run(() => unitOfWork.PhoneBookRepository.GetByID(id));
            //Get(p => p.Id == id,
               // includeProperties: "Entries").FirstOrDefault()
            //);
        }


        [HttpPost("createPhoneBook")]
        public async Task CreatePhoneBook(Domain.Entities.PhoneBook phoneBook)
        {
            await Task.Run(() => InsertPhoneBook(phoneBook));
        }

        private void InsertPhoneBook(Domain.Entities.PhoneBook phoneBook)
        {
            unitOfWork.PhoneBookRepository.Insert(phoneBook);
            unitOfWork.Save();
        }

        #endregion //phonebook

        #region //entry

        [HttpGet("getEntries")]
        public async Task<List<Entry>> GetEntries(int phoneBookId,string nameSearchTerm=null)
        {
            // (e.Name.Contains(nameSearchTerm) || !e.Name.Equals(nameSearchTerm) )
            return await Task.Run(() => unitOfWork.EntryRepository.Get(e => e.PhoneBookId == phoneBookId &&
            e.Name.Contains(nameSearchTerm)).ToList());
        }

        [HttpGet("getEntryById")]
        public async Task<Entry> GetEntryById(int id)
        {
            return await Task.Run(() => unitOfWork.EntryRepository.Get(e => e.Id == id).FirstOrDefault() );
        }

        [HttpPost("createEntry")]
        public async Task CreateEntry(Entry entry)
        {
            await Task.Run(() => InsertEntry(entry));
        }

        private void InsertEntry(Entry entry)
        {
            unitOfWork.EntryRepository.Insert(entry);
            unitOfWork.Save();
        }

        #endregion //entry
    }
}