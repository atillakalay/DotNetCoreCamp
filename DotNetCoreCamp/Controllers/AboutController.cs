using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

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
