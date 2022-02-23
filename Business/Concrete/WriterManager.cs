using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class WriterManager : IWriterService
    {
        private IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer writer)
        {
            _writerDal.Add(writer);
        }

        public void Delete(Writer entity)
        {
            _writerDal.Delete(entity);
        }

        public void Update(Writer entity)
        {
            _writerDal.Update(entity);
        }

        public List<Writer> GetAll()
        {
            return _writerDal.GetAll();
        }
        public List<Writer> GetAll(int id)
        {
            return _writerDal.GetAll(w => w.WriterId == id);
        }
        public List<Writer> GetAll(string email)
        {
            return _writerDal.GetAll(w => w.WriterMail == email);
        }

        public Writer GetById(int id)
        {
            return _writerDal.GetById(id);
        }

        public List<Writer> GetListWriterById(int id)
        {
            return _writerDal.GetAll(w => w.WriterId == id);
        }
    }
}
