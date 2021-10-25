using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCamp.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        [HttpPost]
        public IActionResult Index()
        {
            var blogs = _blogManager.GetBlogListWithCategory();
            return View(blogs);
        }

        [HttpGet]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.blogId = id;
            var blog = _blogManager.GetAll(id);
            return View(blog);
        }

        public IActionResult BlogListByWriter()
        {
            var blogs = _blogManager.GetBlogListWithWriter(1);
            return View(blogs);
        }
    }
}
