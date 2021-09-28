using System.Collections.Generic;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetListWithCategory();
    }
}
