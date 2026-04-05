using Core.DataAccess;
using Data.Models;

namespace Access.Abstract
{
    public interface IUserDao : IEntityRepository<User> { }
}
