using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBlogService
    {
        void Add(Blog blog);
        void Delete(Blog blog);
        void Update(Blog blog);
        List<Blog> GetAll();

        List<Blog> GetAll(int id);
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetBlogListWithWriter(int id);
        Blog GetById(int id);
    }
}
