using System.Linq;
using System.Collections.Generic;
using Business.Abstract;
using Access.Abstract;
using Core.Utilities.Result;
using Data.Models;

namespace Business.Concrete
{
    public class PCombDrillService : IPCombDrillService
    {
        private readonly IPCombDrillDao _dao;

        public PCombDrillService(IPCombDrillDao dao)
        {
            _dao = dao;
        }

        public IDataResult<PCombDrill?> Get(int id)
        {
            var drill = _dao.Get(x => x.Id == id && x.DeletedAt == null);

            if (drill == null)
                return new ErrorDataResult<PCombDrill?>(null, "Drill not found.");

            return new SuccessDataResult<PCombDrill?>(drill);
        }

        public IDataResult<PCombDrill?> GetForUser(int id, int userId)
        {
            var drill = _dao.Get(x =>
                x.Id == id &&
                x.UserId == userId &&
                x.DeletedAt == null
            );

            if (drill == null)
                return new ErrorDataResult<PCombDrill?>(null, "Drill not found.");

            return new SuccessDataResult<PCombDrill?>(drill);
        }

        public IDataResult<List<PCombDrill>> GetList()
        {
            var list = _dao
                .GetAll(x => x.DeletedAt == null)
                .ToList();

            return new SuccessDataResult<List<PCombDrill>>(list);
        }

        public IDataResult<List<PCombDrill>> GetByUser(int userId)
        {
            var list = _dao
                .GetAll(x => x.UserId == userId && x.DeletedAt == null)
                .ToList();

            return new SuccessDataResult<List<PCombDrill>>(list);
        }

        public IDataResult<PCombDrill> Add(PCombDrill drill)
        {
            if (string.IsNullOrWhiteSpace(drill.Name))
                drill.Name = "Pre Combination Drill";

            drill.CreatedAt = DateTime.UtcNow;
            drill.UpdatedAt = DateTime.UtcNow;
            drill.DeletedAt = null;

            _dao.Add(drill);

            return new SuccessDataResult<PCombDrill>(
                drill,
                "Pre Combination drill created successfully."
            );
        }

        public IResult SoftDelete(int id)
        {
            var drill = _dao.Get(x => x.Id == id && x.DeletedAt == null);
            if (drill == null)
                return new ErrorResult("Drill not found.");

            drill.DeletedAt = DateTime.UtcNow;
            drill.UpdatedAt = DateTime.UtcNow;

            _dao.Update(drill);

            return new SuccessResult("Drill soft deleted.");
        }

        public IResult Update(PCombDrill drill)
        {
            var existing = _dao.Get(x => x.Id == drill.Id && x.DeletedAt == null);
            if (existing == null)
                return new ErrorResult("Drill not found.");

            drill.UpdatedAt = DateTime.UtcNow;
            _dao.Update(drill);

            return new SuccessResult("Pre comb drill updated.");
        }

        public IResult Delete(int id)
        {
            var drill = _dao.Get(x => x.Id == id && x.DeletedAt == null);
            if (drill == null)
                return new ErrorResult("Drill not found.");

            drill.DeletedAt = DateTime.UtcNow;
            drill.UpdatedAt = DateTime.UtcNow;
            _dao.Update(drill);

            return new SuccessResult("Pre comb drill deleted.");
        }
    }
}

