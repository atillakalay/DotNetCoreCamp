using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll();
        T GetById(int id);
        List<T> GetAll(Expression<Func<T, bool>> filter);

    }
}
