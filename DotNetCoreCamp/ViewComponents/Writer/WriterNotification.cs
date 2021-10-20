using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCamp.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
