using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using PhoneBook.DAL.API.Client;
using PhoneBook.Domain.Interfaces;
using PhoneBook.Web.Models;

namespace PhoneBook.Web.Controllers
{
    public class EntryController : Controller
    {
        private readonly IPhoneBookApiClient phoneBookApiClient;

        public EntryController(IPhoneBookApiClient _phoneBookApiClient)
        {
            phoneBookApiClient = _phoneBookApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int phoneBookId)
        {
            EntryVM entry = new EntryVM { PhoneBookId = phoneBookId };
            return View(entry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(include: "PhoneBookId,Name,PhoneNumber")]EntryVM entryVM)
        {
            var entry = new EntryVM().EntryObj(entryVM);

            await phoneBookApiClient.CreateEntry(entry);
            return RedirectToActionPermanent("Index", "PhoneBook");
        }

        //public async Task<IActionResult> SearchEntries(int phoneBookId, string phoneBookName)
        //{
        //    EntryVM entryVM = new EntryVM { PhoneBookId = phoneBookId };

        //    return View(entryVM);
        //}

        //[HttpPost]
        public async Task<IActionResult> SearchEntries(int phoneBookId, string searchTerm=null)
        {
            var phoneBook = await phoneBookApiClient.GetPhoneBookById(phoneBookId);
            var entries = await phoneBookApiClient.GetEntries(phoneBookId, searchTerm);

            List<EntryVM> entryVMs = new List<EntryVM>();
            foreach(var entry in entries)
            {
                entryVMs.Add(new EntryVM().EntryVMObj(entry));
            }

            PhoneBookEntries phoneBookEntries = new PhoneBookEntries
            {
                PhoneBook = new PhoneBookVM().PhoneBookVMObj(phoneBook),
                Entries = entryVMs,
                PhoneBookId=phoneBook.Id
            };

            return View(phoneBookEntries);
        }
    }
}