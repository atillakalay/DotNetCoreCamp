using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCamp.Controllers
{
    public class AboutController : Controller
    {
        private AboutManager _aboutManager = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
            var socialMedias = _aboutManager.GetAll();
            return View(socialMedias);
        }

        public PartialViewResult SocialMediaAbout()
        {
            var socialMedias = _aboutManager.GetAll();
            return PartialView();
        }
    }
}
