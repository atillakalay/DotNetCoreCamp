using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace DotNetCoreCamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var categories = _categoryManager.GetAll();
            return View(categories);
        }
    }
}
