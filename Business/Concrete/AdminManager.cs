

using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class AdminManager : IAdminService
    {
        private IAdminDal adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            this.adminDal = adminDal;
        }

        public void Add(Admin entity)
        {
            adminDal.Add(entity);
        }

        public void Delete(Admin entity)
        {
            adminDal.Delete(entity);
        }

        public void Update(Admin entity)
        {
            adminDal.Update(entity);
        }

        public List<Admin> GetAll()
        {
            return adminDal.GetAll();
        }

        public Admin GetById(int id)
        {
            return adminDal.GetById(id);
        }
    }
}
