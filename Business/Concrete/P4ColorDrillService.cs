using System.Linq;
using System.Collections.Generic;
using Business.Abstract;
using Access.Abstract;
using Core.Utilities.Result;
using Data.Models;

namespace Business.Concrete
{
    public class P4ColorDrillService : IP4ColorDrillService
    {
        private readonly IP4ColorDrillDao _dao;

        public P4ColorDrillService(IP4ColorDrillDao dao)
        {
            _dao = dao;
        }

        public IDataResult<P4ColorDrill?> Get(int id)
        {
            var drill = _dao.Get(x => x.Id == id && x.DeletedAt == null);
            if (drill == null)
                return new ErrorDataResult<P4ColorDrill?>(null, "Drill not found.");

            return new SuccessDataResult<P4ColorDrill?>(drill);
        }

        public IDataResult<P4ColorDrill?> GetForUser(int id, int userId)
        {
            var drill = _dao.Get(x =>
                x.Id == id &&
                x.UserId == userId &&
                x.DeletedAt == null
            );

            if (drill == null)
                return new ErrorDataResult<P4ColorDrill?>(null, "Drill not found.");

            return new SuccessDataResult<P4ColorDrill?>(drill);
        }

        public IDataResult<List<P4ColorDrill>> GetList()
        {
            var list = _dao
                .GetAll(x => x.DeletedAt == null)
                .ToList();

            return new SuccessDataResult<List<P4ColorDrill>>(list);
        }

        public IDataResult<List<P4ColorDrill>> GetByUser(int userId)
        {
            var list = _dao
                .GetAll(x => x.UserId == userId && x.DeletedAt == null)
                .ToList();

            return new SuccessDataResult<List<P4ColorDrill>>(list);
        }

        public IDataResult<P4ColorDrill> Add(P4ColorDrill drill)
        {

            if (string.IsNullOrWhiteSpace(drill.Name))
                drill.Name = "Pre 4 Color Drill";

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

            return new SuccessDataResult<P4ColorDrill>(
                drill,
                "Pre 4 Color drill created successfully."
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
        public IResult Update(P4ColorDrill drill)
        {
            var existing = _dao.Get(x => x.Id == drill.Id && x.DeletedAt == null);
            if (existing == null)
                return new ErrorResult("Drill not found.");

            drill.UpdatedAt = DateTime.UtcNow;
            _dao.Update(drill);

            return new SuccessResult("Pre 4color drill updated.");
        }

        public IResult Delete(int id)
        {
            var drill = _dao.Get(x => x.Id == id && x.DeletedAt == null);
            if (drill == null)
                return new ErrorResult("Drill not found.");

            drill.DeletedAt = DateTime.UtcNow;
            drill.UpdatedAt = DateTime.UtcNow;
            _dao.Update(drill);

            return new SuccessResult("Pre 4color drill deleted.");
        }
    }
}
