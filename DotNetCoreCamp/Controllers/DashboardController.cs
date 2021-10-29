using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DotNetCoreCamp.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
