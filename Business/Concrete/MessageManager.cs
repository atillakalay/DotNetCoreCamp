using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public void Add(Message entity)
        {
            _messageDal.Add(entity);
        }

        public void Delete(Message entity)
        {
            _messageDal.Delete(entity);
        }
        public void Update(Message entity)
        {
            _messageDal.Update(entity);
        }
        public List<Message> GetAll()
        {
            return _messageDal.GetAll();
        }
        public List<Message> GetAll(string receiveEmail)
        {
            return _messageDal.GetAll(w => w.Receiver == receiveEmail);
        }
        public Message GetById(int id)
        {
            return _messageDal.GetById(id);
        }
    }
}