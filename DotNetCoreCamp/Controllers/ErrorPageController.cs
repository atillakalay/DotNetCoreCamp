using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreCamp.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult ErrorNotFound(int code)
        {
            return View();
        }
    }
}
