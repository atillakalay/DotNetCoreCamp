using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreCamp.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
        private WriterManager _writerManager = new WriterManager(new EfWriterRepository());
        private BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        Context context = new Context();

        [HttpGet]


        public IActionResult Index()
        {
            var blogs = _blogManager.GetBlogListWithCategory();
            return View(blogs);
        }

        [AllowAnonymous]
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
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId)
                .FirstOrDefault();
            var values = _blogManager.GetBlogListWithWriter(writerId);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {

            List<SelectListItem> categories = (from category in _categoryManager.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = category.CategoryName,
                                                   Value = category.CategoryId.ToString()
                                               }).ToList();
            ViewBag.categoriesList = categories;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            var userMail = User.Identity.Name;
            var writerId = _writerManager.GetAll(userMail).Select(w => w.WriterId).FirstOrDefault();
            var writerValues = _writerManager.GetById(writerId);
            BlogValidator blogValidator = new BlogValidator();
            ValidationResult validationResult = blogValidator.Validate(blog);
            if (validationResult.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = writerId;
                _blogManager.Add(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            GetCategoryList();
            return View();
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogDetails = _blogManager.GetById(id);
            GetCategoryList();
            return View(blogDetails);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            var userMail = User.Identity.Name;
            var writerId = _writerManager.GetAll(userMail).Select(w => w.WriterId).FirstOrDefault();
            var writerValues = _writerManager.GetById(writerId);
            var value = _blogManager.GetById(blog.BlogId);
            blog.WriterId = writerId;
            blog.BlogCreateDate = value.BlogCreateDate;
            blog.BlogStatus = true;
            _blogManager.Update(blog);
            return RedirectToAction("BlogListByWriter");
        }

        public void GetCategoryList()
        {
            List<SelectListItem> categories = (from c in _categoryManager.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = c.CategoryName,
                                                   Value = c.CategoryId.ToString()
                                               }).ToList();
            ViewBag.categoriesList = categories;
        }
    }
}
