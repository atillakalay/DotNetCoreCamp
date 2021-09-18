using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        void Add(Category category);
        void Delete(Category category);
        void Update(Category category);
        List<Category> GetAll();
        Category GetById(int id);


    }
}
