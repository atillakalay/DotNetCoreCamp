using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCamp.Controllers
{
    public class BlogController : Controller
    {
        private BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var blogs = _blogManager.GetAll();
            return View(blogs);
        }
    }
}
