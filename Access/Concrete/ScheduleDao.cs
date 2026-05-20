using Access.Abstract;
using Access.Contexts;
using Core.DataAccess;
using Data.Models;

namespace Access.Concrete
{
    public class ScheduleDao
        : EntityRepository<Schedule, TrainingDbContext>,
          IScheduleDao
    {
    }
}