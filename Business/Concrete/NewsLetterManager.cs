﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

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
    }
}
