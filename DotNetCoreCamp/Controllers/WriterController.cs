using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DotNetCoreCamp.Controllers
{

    public class WriterController : Controller
    {
        private WriterManager _writerManager = new WriterManager(new EfWriterRepository());

        [Authorize]
        public IActionResult Index()
        {
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

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var writerValues = _writerManager.GetById(1);
            return View(writerValues);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer, string passwordAgain)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid && writer.WriterPassword == passwordAgain)
            {
                writer.WriterStatus = true;
                _writerManager.Update(writer);
                return RedirectToAction("Index", "Dashboard");
            }
            else if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            else
            {
                ModelState.AddModelError("WriterPassword", "Girdiğiniz Şifreler Eşleşmiyor! Lütfen Tekrar Deneyiniz");
            }
            return View();
        }
    }
}
