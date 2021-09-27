using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCamp.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
