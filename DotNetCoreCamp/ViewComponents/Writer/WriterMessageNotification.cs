using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCamp.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private MessageManager _messageManager = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            string receiveEmail;
            receiveEmail = "deneme@gmail.com";

            var values = _messageManager.GetAll(receiveEmail);
            return View(values);
        }
    }
}
