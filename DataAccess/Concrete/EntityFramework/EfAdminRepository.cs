using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAdminRepository : GenericRepository<Admin>, IAdminDal
    {
    }
}
