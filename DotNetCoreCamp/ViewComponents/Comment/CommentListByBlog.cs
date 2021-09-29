using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCamp.ViewComponents
{
    public class CommentListByBlog : ViewComponent
    {
        private CommentManager _commentManager = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke(int id)
        {
            var comments = _commentManager.GetAll(id);
            return View(comments);
        }
    }
}
