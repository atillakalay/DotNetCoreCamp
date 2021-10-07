using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCamp.Controllers
{
    public class NewsLetterController : Controller
    {
        private NewsLetterManager _newsLetterManager = new NewsLetterManager(new EfNewsLetterRepository());
        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.MailStatus=true;
            _newsLetterManager.Add(newsLetter);
            return PartialView();
        }
    }
}
