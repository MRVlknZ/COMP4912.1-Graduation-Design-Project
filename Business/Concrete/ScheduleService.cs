using Business.Abstract;
using Access.Abstract;
using Core.Utilities.Result;
using Data.Models;

namespace Business.Concrete
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleDao _dao;

        public ScheduleService(IScheduleDao dao)
        {
            _dao = dao;
        }

        public IDataResult<Schedule?> Get(int id)
        {
            var schedule = _dao.Get(x => x.Id == id && x.DeletedAt == null);

            if (schedule == null)
                return new ErrorDataResult<Schedule?>(null, "Schedule not found.");

            return new SuccessDataResult<Schedule?>(schedule);
        }

        public IDataResult<List<Schedule>> GetByUser(int userId)
        {
            var list = _dao
                .GetAll(x => x.UserId == userId && x.DeletedAt == null)
                .ToList();

            return new SuccessDataResult<List<Schedule>>(list);
        }

        public IDataResult<Schedule> Add(Schedule schedule)
        {
            schedule.CreatedAt = DateTime.UtcNow;
            schedule.UpdatedAt = DateTime.UtcNow;
            schedule.DeletedAt = null;

            _dao.Add(schedule);

            return new SuccessDataResult<Schedule>(
                schedule,
                "Schedule created successfully."
            );
        }

        public IResult Update(Schedule schedule)
        {
            var existing = _dao.Get(x => x.Id == schedule.Id && x.DeletedAt == null);

            if (existing == null)
                return new ErrorResult("Schedule not found.");

            schedule.CreatedAt = existing.CreatedAt;
            schedule.DeletedAt = null;
            schedule.UpdatedAt = DateTime.UtcNow;

            _dao.Update(schedule);

            return new SuccessResult("Schedule updated.");
        }

        public IResult Delete(int id)
        {
            var schedule = _dao.Get(x => x.Id == id && x.DeletedAt == null);

            if (schedule == null)
                return new ErrorResult("Schedule not found.");

            schedule.DeletedAt = DateTime.UtcNow;
            schedule.UpdatedAt = DateTime.UtcNow;

            _dao.Update(schedule);

            return new SuccessResult("Schedule deleted.");
        }

        public IResult SoftDelete(int id)
        {
            var schedule = _dao.Get(x => x.Id == id && x.DeletedAt == null);

            if (schedule == null)
                return new ErrorResult("Schedule not found.");

            schedule.DeletedAt = DateTime.UtcNow;
            schedule.UpdatedAt = DateTime.UtcNow;

            _dao.Update(schedule);

            return new SuccessResult("Schedule soft deleted.");
        }
    }
}