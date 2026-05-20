using Core.Utilities.Result;
using Data.Models;

namespace Business.Abstract
{
    public interface IScheduleService
    {
        IDataResult<Schedule> Add(Schedule schedule);
        IDataResult<Schedule?> Get(int id);
        IDataResult<List<Schedule>> GetByUser(int userId);

        IResult Update(Schedule schedule);

        IResult Delete(int id);
        IResult SoftDelete(int id);
    }
}