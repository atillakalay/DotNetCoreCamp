﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCamp.Controllers
{
    public class BlogController : Controller
    {
        private BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var blogs = _blogManager.GetBlogListWithCategory();
            return View(blogs);
        }

        public IActionResult BlogReadAll(int id)
        {
            var blog = _blogManager.GetById(id);
            return View(blog);
        }
    }
}
