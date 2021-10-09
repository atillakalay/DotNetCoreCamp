using Microsoft.AspNetCore.Mvc;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;

namespace DotNetCoreCamp.Controllers
{
    public class RegisterController : Controller
    {
        private WriterManager _writerManager = new WriterManager(new EfWriterRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult result = writerValidator.Validate(writer);
            if (result.IsValid && writer.WriterPassword == writer.WriterPasswordRepeat)
            {
                writer.WriterStatus = true;
                writer.WriterAbout = "Deneme Test";
                _writerManager.Add(writer);
                return RedirectToAction("Index", "Blog");
            }
            else if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            else
            {
                ModelState.AddModelError("WriterPassword", "Girdiğiniz Şifreler Eşleşmedi Lütfen Tekrar Deneyin");
            }
            return View();
        }
    }
}
