using Microsoft.AspNetCore.Mvc;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;

namespace DotNetCoreCamp.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        private Message2Manager _message2Manager = new Message2Manager(new EfMessage2Repository());
        public IActionResult InBox()
        {
            var messages = _message2Manager.GetListMessageByWriter(id: 3);
            return View(messages);
        }
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var messages = _message2Manager.GetById(id);
            return View(messages);
        }
    }
}
