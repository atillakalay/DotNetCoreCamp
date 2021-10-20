using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IGenericService<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetAll();
        T GetById(int id);
    }
}
