using System;
using Microsoft.AspNetCore.Mvc;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace DotNetCoreCamp.Controllers
{
    public class ContactController : Controller
    {
        private ContactManager _contactManager = new ContactManager(new EfContactRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.ContactStatus = true;
            _contactManager.Add(contact);
            return RedirectToAction("Index", "Blog");
        }
    }
}
