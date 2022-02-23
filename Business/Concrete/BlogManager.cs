using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Add(Blog blog)
        {
            _blogDal.Add(blog);
        }

        public void Delete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public void Update(Blog blog)
        {
            _blogDal.Update(blog);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public List<Blog> GetBlogListWithWriter(int id)
        {
            return _blogDal.GetAll(b => b.WriterId == id);
        }

        public List<Blog> GetAll(int id)
        {
            return _blogDal.GetAll(b => b.BlogId == id);
        }

        public List<Blog> GetLastThreeBlog()
        {
            return _blogDal.GetAll().Take(3).ToList();
        }
        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }
    }
}
