using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCamp.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        NewsLetterManager _newsLetterManager = new NewsLetterManager(new EfNewsLetterRepository());

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            _newsLetterManager.Add(newsLetter);
            return PartialView();
        }
    }
}