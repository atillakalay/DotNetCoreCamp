
using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetSendBoxWithMessageByWriter(int id)
        {
            using (var context = new Context())
            {
                return context.Messages2.Include(x => x.ReceiverUserWriter).Where(y => y.SenderId == id).ToList();
            }
        }

        public List<Message2> GetInboxWithMessageByWriter(int id)
        {
            using (var context = new Context())
            {
                return context.Messages2.Include(x => x.SenderUserWriter).Where(x => x.ReceiverId == id).ToList();
            }
        }
    }
}