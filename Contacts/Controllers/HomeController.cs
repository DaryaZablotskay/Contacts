using Contacts.Models;
using Contacts.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Services.IServices;
using Contacts.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IContactRepository _contactRepository;
        private readonly ContactContext _contactContext;

        public HomeController(IContactService contactService, IContactRepository contactRepository, ContactContext contactContext)
        {
            _contactService = contactService;
            _contactRepository = contactRepository;
            _contactContext = contactContext;
        }
        public async Task<IActionResult> Home()
        {
            var contacts = await _contactService.GetContact();
            return View(contacts);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ContactsPage contact = new ContactsPage();
            return PartialView("Add", contact);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContactsPage contact)
        {
            await _contactService.AddContact(contact);

            return Json(new
            {
                isValid = true,
                html = Helper.RenderRazorViewToString(this, "Home",
                    await _contactService.GetContact())
            });
        }

        public async Task<IActionResult> Delete(string mobilePhone)
        {
            await _contactService.DeleteContact(mobilePhone);
            return RedirectToAction("Home");
        }

        [HttpGet]
        public async Task<IActionResult> Update(string mobilePhone)
        {
            var existContact = await _contactRepository.GetAll().SingleOrDefaultAsync(f => f.MobilePhone == mobilePhone);
            ViewBag.Contacts = existContact;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(string mobilePhone, ContactsPage contact)
        {
            await _contactService.UpdateContact(mobilePhone, contact);
            return Json(new
            {
                isValid = true,
                html = Helper.RenderRazorViewToString(this, "Home",
                     await _contactService.GetContact())
            });
        }
    }
}
