using System.Linq;
using System.Collections.Generic;
using Business.Abstract;
using Access.Abstract;
using Core.Utilities.Result;
using Core.Utilities.Constant;
using Data.Models;

namespace Business.Concrete
{
   public class UserService: IUserService
    {
        private readonly IUserDao _dao;
        public UserService(IUserDao dao) => _dao = dao;

        public IResult Add(User user)
        {
            var exists = _dao.GetAll(u => u.Email == user.Email).Any();
            if (exists)
            {
                return new ErrorResult("This email address is already registered.");
            }

            _dao.Add(user);
            return new SuccessResult(ResultConstant.RecordCreated);
        }

        public IResult Update(User user)
        {
            _dao.Update(user);
            return new SuccessResult(ResultConstant.RecordUpdated);
        }

        public IResult Delete(int id)
        {
            var e = _dao.Get(x => x.Id == id);
            if (e == null) return new ErrorResult(ResultConstant.RecordNotFound);
            _dao.Delete(e);
            return new SuccessResult(ResultConstant.RecordDeleted);
        }

        public IDataResult<User?> Get(int id)
            => new SuccessDataResult<User?>(_dao.Get(x => x.Id == id));

        public IDataResult<List<User>> GetList()
            => new SuccessDataResult<List<User>>(_dao.GetAll().ToList());
        public IDataResult<List<User>> GetActive()
            => new SuccessDataResult<List<User>>(_dao.GetAll(x => x.IsActive).ToList());


        public IResult Ban(int userid)
        {
            var u = _dao.Get(x => x.Id == userid);
            if (u == null)
            {
                return new ErrorResult(ResultConstant.RecordNotFound);
            }
            u.IsActive = false;
            _dao.Update(u);
            return new SuccessResult("Kullanıcı banlandı");
        }

        public IResult Unban(int userid)
        {
            var u = _dao.Get(x => x.Id == userid);
            if (u == null)
            {
                return new ErrorResult(ResultConstant.RecordNotFound);
            }
            u.IsActive = true;
            _dao.Update(u);
            return new SuccessResult("Kullanıcı aktive edildi");
        }
    }
}
