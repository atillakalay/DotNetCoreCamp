using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            _message2Dal = message2Dal;
        }

        public void Add(Message2 entity)
        {
            _message2Dal.Add(entity);
        }

        public void Delete(Message2 entity)
        {
            _message2Dal.Delete(entity);
        }

        public void Update(Message2 entity)
        {
            _message2Dal.Update(entity);
        }

        public List<Message2> GetAll()
        {
            return _message2Dal.GetAll();
        }

        public List<Message2> GetAll(int id)
        {
            return _message2Dal.GetAll(w => w.ReceiverId == id);
        }

        public Message2 GetById(int id)
        {
            return _message2Dal.GetById(id);
        }

        Message2 IGenericService<Message2>.GetById(int id)
        {
            return _message2Dal.GetById(id);
        }
    }
}