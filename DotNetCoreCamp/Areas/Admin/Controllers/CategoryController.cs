using Microsoft.AspNetCore.Mvc;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using X.PagedList;

namespace DotNetCoreCamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int pageNumber = 1)
        {
            var categories = _categoryManager.GetAll().ToPagedList(pageNumber, 5);
            return View(categories);
        }
    }
}
