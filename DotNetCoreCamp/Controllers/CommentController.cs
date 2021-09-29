using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;


namespace DotNetCoreCamp.Controllers
{
    public class CommentController : Controller
    {
        private CommentManager _commentManager = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PartialAddComment()
        {
            return View();
        }
        public IActionResult CommentListByBlog(int id)
        {
            var comments = _commentManager.GetAll(id);
            return View();
        }
    }
}
