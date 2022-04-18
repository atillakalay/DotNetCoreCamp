using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public void Add(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public void Update(AppUser entity)
        {
            _userDal.Update(entity);
        }

        public List<AppUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public AppUser GetById(int id)
        {
            return _userDal.GetById(id);
        }
    }
}