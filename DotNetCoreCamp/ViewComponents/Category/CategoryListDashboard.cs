using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCamp.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var values = _categoryManager.GetAll();
            return View(values);
        }
    }
}
