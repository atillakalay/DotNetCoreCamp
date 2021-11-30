using System.Collections.Generic;
using System.Linq;
using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetListMessageByWriter(int id)
        {
            using (var context = new Context())
            {
                return context.Messages2.Include(w => w.SenderUserWriter).Where(w=>w.ReceiverId==id).ToList();
            }
        }
    }
}
