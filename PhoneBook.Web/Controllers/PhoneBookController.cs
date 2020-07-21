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
    public class PhoneBookController : Controller
    {
        private readonly IPhoneBookApiClient phoneBookApiClient;
        public PhoneBookController(IPhoneBookApiClient _phoneBookApiClient)
        {
            phoneBookApiClient = _phoneBookApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var phoneBooks = await phoneBookApiClient.GetPhoneBooks();

            List<PhoneBookVM> phoneBookVMs = new List<PhoneBookVM>();
           
            foreach (var phoneBook in phoneBooks)
            {
                phoneBookVMs.Add(new PhoneBookVM().PhoneBookVMObj(phoneBook));
            }

            return View(phoneBookVMs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(include: "Name")]PhoneBookVM phoneBookVM)
        {
            var phoneBook = new PhoneBookVM().PhoneBookObj(phoneBookVM);

            await phoneBookApiClient.CreatePhoneBook(phoneBook);
           return  RedirectToAction(nameof(Index));
        }
    }
}