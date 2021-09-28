using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreCamp.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PartialAddComment()
        {
            return View();
        } 
        public IActionResult CommentListByBlog()
        {
            return View();
        }
    }
}
