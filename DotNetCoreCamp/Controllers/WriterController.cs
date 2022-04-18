using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DotNetCoreCamp.Models;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DotNetCoreCamp.Controllers
{

    public class WriterController : Controller
    {
        WriterManager _writerManager = new WriterManager(new EfWriterRepository());
        private readonly UserManager<AppUser> _userManager;
        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.userMail = userMail;
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.Mail = values.Email;
            model.NameSurname = values.NameSurname;
            model.Username = values.UserName;
            model.ImageUrl = values.ImageUrl;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel userUpdateViewModel)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.NameSurname = userUpdateViewModel.NameSurname;
            values.ImageUrl = userUpdateViewModel.ImageUrl;
            values.Email = userUpdateViewModel.Mail;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, userUpdateViewModel.Password);
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage addProfileImage)
        {
            Writer writer = new Writer();
            if (addProfileImage.WriterImage != null)
            {
                var extension = Path.GetExtension(addProfileImage.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                addProfileImage.WriterImage.CopyTo(stream);
                writer.WriterImage = newImageName;
            }
            writer.WriterMail = addProfileImage.WriterMail;
            writer.WriterName = addProfileImage.WriterName;
            writer.WriterPassword = addProfileImage.WriterPassword;
            writer.WriterPasswordRepeat = addProfileImage.WriterPasswordRepeat;
            writer.WriterStatus = true;
            writer.WriterAbout = addProfileImage.WriterAbout;
            _writerManager.Add(writer);
            return RedirectToAction("Index", "Dashboard");
        }
    }

}
