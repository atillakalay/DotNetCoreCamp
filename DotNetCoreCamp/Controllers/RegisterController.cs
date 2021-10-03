using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using Business.ValiditonRules;
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
            if (result.IsValid)
            {
                writer.WriterStatus = true;
                writer.WriterAbout = "Deneme Test";
                _writerManager.Add(writer);
                return View("Index", "Blog");
            }

            foreach (var results in result.Errors)
            {
                ModelState.AddModelError(results.PropertyName, results.ErrorMessage);
            }

            return View();
        }
    }
}
