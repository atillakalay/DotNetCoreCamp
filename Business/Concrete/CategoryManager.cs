using System;
using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private EfCategoryRepository _efCategoryRepository;

        public CategoryManager(EfCategoryRepository efCategoryRepository)
        {
            _efCategoryRepository = efCategoryRepository;
        }

        public void Add(Category category)
        {

            _efCategoryRepository.Add(category);
        }

        public void Delete(Category category)
        {
            _efCategoryRepository.Delete(category);
        }

        public void Update(Category category)
        {
            _efCategoryRepository.Update(category);
        }

        public List<Category> GetAll()
        {
            return _efCategoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _efCategoryRepository.GetById(id);
        }
    }
}
