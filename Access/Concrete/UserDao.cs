using Access.Abstract;
using Access.Contexts;
using Core.DataAccess;
using Data.Models;

namespace Access.Concrete
{
    public class UserDao : EntityRepository<User, TrainingDbContext>, IUserDao { }
}
