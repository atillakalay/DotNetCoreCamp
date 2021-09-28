using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBlogService
    {
        void Add(Blog blog);
        void Delete(Blog blog);
        void Update(Blog blog);
        List<Blog> GetAll();
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetAll(int id);
        Blog GetById(int id);
    }
}
