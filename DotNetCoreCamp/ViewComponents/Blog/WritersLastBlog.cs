using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCamp.ViewComponents.Blog
{
    public class WritersLastBlog : ViewComponent
    {
        private BlogManager _blogManager = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var blogs = _blogManager.GetBlogListWithWriter(1);
            return View(blogs);
        }
    }
}
