using System.Linq;
using System.Collections.Generic;
using Business.Abstract;
using Access.Abstract;
using Core.Utilities.Result;
using Core.Utilities.Constant;
using Data.Models;

namespace Business.Concrete
{
    public class CFocusDrillService : ICFocusDrillService
    {
        private readonly ICFocusDrillDao _dao;
        public CFocusDrillService(ICFocusDrillDao dao) => _dao = dao;

        public IDataResult<CFocusDrill?> Get(int id)
        {
            var drill = _dao.Get(x => x.Id == id && x.DeletedAt == null);

            if (drill == null)
                return new ErrorDataResult<CFocusDrill?>(null, "Drill not found.");

            return new SuccessDataResult<CFocusDrill?>(drill);
        }

        public IDataResult<CFocusDrill?> GetForUser(int id, int userId)
        {
            var drill = _dao.Get(x =>
                x.Id == id &&
                x.UserId == userId &&
                x.DeletedAt == null
            );

            if (drill == null)
                return new ErrorDataResult<CFocusDrill?>(null, "Drill not found.");

            return new SuccessDataResult<CFocusDrill?>(drill);
        }

        public IDataResult<List<CFocusDrill>> GetList()
        {
            var list = _dao
                .GetAll(x => x.DeletedAt == null)
                .ToList();

            return new SuccessDataResult<List<CFocusDrill>>(list);
        }

        public IDataResult<List<CFocusDrill>> GetByUser(int userId)
        {
            var list = _dao
                .GetAll(x => x.UserId == userId && x.DeletedAt == null)
                .ToList();

            return new SuccessDataResult<List<CFocusDrill>>(list);
        }

        public IDataResult<CFocusDrill> Add(CFocusDrill drill)
        {
            if (string.IsNullOrWhiteSpace(drill.Name))
                drill.Name = "Custom Focus Drill";

            switch (drill.DifficultyLevel)
            {
                case "Easy":
                    drill.AutoIncreaseDifficulty = false;
                    break;

                case "Medium":
                case "Hard":
                    drill.AutoIncreaseDifficulty = true;
                    break;
            }

            drill.CreatedAt = DateTime.UtcNow;
            drill.UpdatedAt = DateTime.UtcNow;
            drill.DeletedAt = null;

            _dao.Add(drill);

            return new SuccessDataResult<CFocusDrill>(
                drill,
                "Custom Focus drill created successfully."
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

        public IResult Update(CFocusDrill drill)
        {
            var existing = _dao.Get(x => x.Id == drill.Id && x.DeletedAt == null);
            if (existing == null)
                return new ErrorResult("Drill not found.");

            drill.UpdatedAt = DateTime.UtcNow;
            _dao.Update(drill);

            return new SuccessResult("Custom focus drill updated.");
        }

        public IResult Delete(int id)
        {
            var drill = _dao.Get(x => x.Id == id && x.DeletedAt == null);
            if (drill == null)
                return new ErrorResult("Drill not found.");

            drill.DeletedAt = DateTime.UtcNow;
            drill.UpdatedAt = DateTime.UtcNow;
            _dao.Update(drill);

            return new SuccessResult("Custom focus drill deleted.");
        }
    }
}
