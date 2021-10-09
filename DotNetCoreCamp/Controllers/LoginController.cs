using System.Linq;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace DotNetCoreCamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer writer)
        {
            Context context = new Context();
            var dataValue = context.Writers.FirstOrDefault(w =>
                w.WriterMail == writer.WriterMail && w.WriterPassword == writer.WriterPassword);
            if (dataValue!=null)
            {
                HttpContext.Session.SetString("username",writer.WriterMail);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                return View();
            }
        }
    }
}
