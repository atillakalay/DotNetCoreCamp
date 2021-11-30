using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
    }
}
