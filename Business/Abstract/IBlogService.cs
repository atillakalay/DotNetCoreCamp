using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> GetAll(int id);
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetBlogListWithWriter(int id);
    }
}
