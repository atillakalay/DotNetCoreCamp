using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCamp.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
