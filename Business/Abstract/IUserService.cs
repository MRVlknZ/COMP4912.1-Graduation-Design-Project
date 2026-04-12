using Core.Utilities.Result;
using Data.Models;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(int id);

        IDataResult<User?> Get(int id);
        IDataResult<List<User>> GetList();
        IDataResult<List<User>> GetActive();

        IResult Ban(int userId);
        IResult Unban(int userId);
    }
}
