using System.Collections.Generic;
using System.Linq;
using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            using (var context = new Context())
            {
                return context.Blogs.Include(x => x.Category).ToList();
            }
        }
    }
}
