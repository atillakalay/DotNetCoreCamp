using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCamp.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        private NotificationManager _notificationManager = new NotificationManager(new EfNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var notifications = _notificationManager.GetAll();
            return View(notifications);
        }
    }
}
