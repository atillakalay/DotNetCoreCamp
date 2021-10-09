using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DotNetCoreCamp.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
