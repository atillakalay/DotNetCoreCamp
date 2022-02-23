using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCamp.ViewComponents.Category
{
    public class CategoryList : ViewComponent
    {
        private CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());

        public IViewComponentResult Invoke()
        {
            var categories = _categoryManager.GetAll();
            return View(categories);
        }
    }
}
