using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;


namespace DotNetCoreCamp.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private CommentManager _commentManager = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment comment)
        {
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            comment.BlogId = 2;
            _commentManager.Add(comment);
            return PartialView();
        }
        [HttpPost]
        public IActionResult CommentListByBlog(int id)
        {
            var comments = _commentManager.GetAll(id);
            return View();
        }
    }
}
