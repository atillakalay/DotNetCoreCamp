using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCamp.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        private WriterManager writerManager = new WriterManager(new EfWriterRepository());
        public IViewComponentResult Invoke()
        {
            var userEmail = User.Identity.Name;
             var writers = writerManager.GetAll(email:userEmail);
            return View(writers);
        }
    }
}
