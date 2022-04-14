using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DotNetCoreCamp.Controllers
{
    public class DashboardController : Controller
    {
        private BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        private CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
        [AllowAnonymous]
        public IActionResult Index()
        {
            Context context = new Context();
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.blogsCount = _blogManager.GetAll().Count;
            ViewBag.blogCountByWriter = _blogManager.GetBlogListWithWriter(2).Count;
            ViewBag.categoriesCount = _categoryManager.GetAll().Count;
            return View();
        }
    }
}
