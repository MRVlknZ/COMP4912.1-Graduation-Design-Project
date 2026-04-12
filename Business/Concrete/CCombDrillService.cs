using System.Linq;
using System.Collections.Generic;
using Business.Abstract;
using Access.Abstract;
using Core.Utilities.Result;
using Core.Utilities.Constant;
using Data.Models;

namespace Business.Concrete
{
    public class CCombDrillService : ICCombDrillService
    {
        private readonly ICCombDrillDao _dao;

        public CCombDrillService(ICCombDrillDao dao)
        {
            _dao = dao;
        }

        public IDataResult<CCombDrill?> Get(int id)
        {
            var drill = _dao.Get(x => x.Id == id && x.DeletedAt == null);

            if (drill == null)
                return new ErrorDataResult<CCombDrill?>(null, "Drill not found.");

            return new SuccessDataResult<CCombDrill?>(drill);
        }

        public IDataResult<CCombDrill?> GetForUser(int id, int userId)
        {
            var drill = _dao.Get(x =>
                x.Id == id &&
                x.UserId == userId &&
                x.DeletedAt == null
            );

            if (drill == null)
                return new ErrorDataResult<CCombDrill?>(null, "Drill not found.");

            return new SuccessDataResult<CCombDrill?>(drill);
        }

        public IDataResult<List<CCombDrill>> GetList()
        {
            var list = _dao
                .GetAll(x => x.DeletedAt == null)
                .ToList();

            return new SuccessDataResult<List<CCombDrill>>(list);
        }

        public IDataResult<List<CCombDrill>> GetByUser(int userId)
        {
            var list = _dao
                .GetAll(x => x.UserId == userId && x.DeletedAt == null)
                .ToList();

            return new SuccessDataResult<List<CCombDrill>>(list);
        }

        public IDataResult<CCombDrill> Add(CCombDrill drill)
        {
            if (string.IsNullOrWhiteSpace(drill.Name))
                drill.Name = "Custom Combination Drill";


            drill.CreatedAt = DateTime.UtcNow;
            drill.UpdatedAt = DateTime.UtcNow;
            drill.DeletedAt = null;

            _dao.Add(drill);

            return new SuccessDataResult<CCombDrill>(
                drill,
                "Custom Combination drill created successfully."
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

        public IResult Update(CCombDrill drill)
        {
            var existing = _dao.Get(x => x.Id == drill.Id && x.DeletedAt == null);
            if (existing == null)
                return new ErrorResult("Drill not found.");

            drill.UpdatedAt = DateTime.UtcNow;
            _dao.Update(drill);

            return new SuccessResult("Custom Comb drill updated.");
        }

        public IResult Delete(int id)
        {
            var drill = _dao.Get(x => x.Id == id && x.DeletedAt == null);
            if (drill == null)
                return new ErrorResult("Drill not found.");

            drill.DeletedAt = DateTime.UtcNow;
            drill.UpdatedAt = DateTime.UtcNow;
            _dao.Update(drill);

            return new SuccessResult("Custom comb drill deleted.");
        }
    }
}
