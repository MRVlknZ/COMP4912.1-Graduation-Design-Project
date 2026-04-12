using Business.Abstract;
using Access.Abstract;
using Core.Utilities.Result;
using Data.Models;

namespace Business.Concrete
{
    public class CColorDrillService : ICColorDrillService
    {
        private readonly ICColorDrillDao _dao;

        public CColorDrillService(ICColorDrillDao dao)
        {
            _dao = dao;
        }

        public IDataResult<CColorDrill?> Get(int id)
        {
            var drill = _dao.Get(x => x.Id == id && x.DeletedAt == null);
            if (drill == null)
                return new ErrorDataResult<CColorDrill?>(null, "Drill not found.");

            return new SuccessDataResult<CColorDrill?>(drill);
        }


        public IDataResult<CColorDrill?> GetForUser(int id, int userId)
        {
            var drill = _dao.Get(x =>
                x.Id == id &&
                x.UserId == userId &&
                x.DeletedAt == null
            );

            if (drill == null)
                return new ErrorDataResult<CColorDrill?>(null, "Drill not found.");

            return new SuccessDataResult<CColorDrill?>(drill);
        }


        public IDataResult<List<CColorDrill>> GetByUser(int userId)
        {
            var list = _dao
                .GetAll(x => x.UserId == userId && x.DeletedAt == null)
                .ToList();

            return new SuccessDataResult<List<CColorDrill>>(list);
        }

        public IDataResult<CColorDrill> Add(CColorDrill drill)
        {
            if (string.IsNullOrWhiteSpace(drill.Name))
                drill.Name = "Custom Color Drill";

            switch (drill.DifficultyLevel)
            {
                case "Easy":
                    drill.IsRandomOrder = false;
                    break;
                case "Medium":
                case "Hard":
                    drill.IsRandomOrder = true;
                    break;
            }

            drill.CreatedAt = DateTime.UtcNow;
            drill.UpdatedAt = DateTime.UtcNow;
            drill.DeletedAt = null;

            _dao.Add(drill);

            return new SuccessDataResult<CColorDrill>(drill, "Custom color drill created successfully.");
        }

        public IResult Update(CColorDrill drill)
        {
            var existing = _dao.Get(x => x.Id == drill.Id && x.DeletedAt == null);
            if (existing == null)
                return new ErrorResult("Drill not found.");

            drill.UpdatedAt = DateTime.UtcNow;
            _dao.Update(drill);

            return new SuccessResult("Custom color drill updated.");
        }

        public IResult Delete(int id)
        {
            var drill = _dao.Get(x => x.Id == id && x.DeletedAt == null);
            if (drill == null)
                return new ErrorResult("Drill not found.");

            drill.DeletedAt = DateTime.UtcNow;
            drill.UpdatedAt = DateTime.UtcNow;
            _dao.Update(drill);

            return new SuccessResult("Custom color drill deleted.");
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
    }

}
