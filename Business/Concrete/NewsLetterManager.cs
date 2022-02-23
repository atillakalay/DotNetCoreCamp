using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class NewsLetterManager : INewsLetterService
    {
        private INewsLetterDal _newsLetterDal;

        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            this._newsLetterDal = newsLetterDal;
        }

        public void Add(NewsLetter newsLetter)
        {
            _newsLetterDal.Add(newsLetter);

        }

        public void Delete(NewsLetter entity)
        {
            _newsLetterDal.Delete(entity);
        }

        public void Update(NewsLetter entity)
        {
            _newsLetterDal.Update(entity);
        }

        public List<NewsLetter> GetAll()
        {
            return _newsLetterDal.GetAll();
        }

        public NewsLetter GetById(int id)
        {
            return _newsLetterDal.GetById(id);
        }
    }
}
