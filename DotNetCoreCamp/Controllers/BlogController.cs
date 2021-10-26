using System;
using System.Collections.Generic;
using System.Linq;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNetCoreCamp.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        [HttpGet]
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

        [HttpGet]
        public IActionResult BlogListByWriter()
        {
            var blogs = _blogManager.GetBlogListWithWriter(1);
            return View(blogs);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categories = (from c in categoryManager.GetAll()
                select new SelectListItem
                {
                    Text = c.CategoryName,
                    Value = c.CategoryId.ToString()
                }).ToList();
            ViewBag.categoriesList = categories;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator blogValidator = new BlogValidator();
            ValidationResult result = blogValidator.Validate(blog);
            if (result.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = 1;
                _blogManager.Add(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
