using Microsoft.AspNetCore.Mvc;

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
