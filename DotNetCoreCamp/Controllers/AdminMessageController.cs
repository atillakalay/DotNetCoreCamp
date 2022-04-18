using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCamp.Controllers
{
    public class AdminMessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
