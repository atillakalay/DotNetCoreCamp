using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DotNetCoreCamp.Controllers
{

    public class WriterController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
    }
}
