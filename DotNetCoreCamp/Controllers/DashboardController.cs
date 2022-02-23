using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCamp.Controllers
{
    public class DashboardController : Controller
    {
        private BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        private CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.blogsCount = _blogManager.GetAll().Count;
            ViewBag.blogCountByWriter = _blogManager.GetBlogListWithWriter(2).Count;
            ViewBag.categoriesCount = _categoryManager.GetAll().Count;
            return View();
        }
    }
}
