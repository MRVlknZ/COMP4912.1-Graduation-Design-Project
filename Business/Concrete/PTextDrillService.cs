using System.Linq;
using System.Collections.Generic;
using Business.Abstract;
using Access.Abstract;
using Core.Utilities.Result;
using Data.Models;

namespace Business.Concrete
{
    public class PTextDrillService : IPTextDrillService
    {
        private readonly IPTextDrillDao _dao;

        public PTextDrillService(IPTextDrillDao dao)
        {
            _dao = dao;
        }

        public IDataResult<PTextDrill?> Get(int id)
        {
            var drill = _dao.Get(x => x.Id == id && x.DeletedAt == null);

            if (drill == null)
                return new ErrorDataResult<PTextDrill?>(null, "Drill not found.");

            return new SuccessDataResult<PTextDrill?>(drill);
        }

        public IDataResult<PTextDrill?> GetForUser(int id, int userId)
        {
            var drill = _dao.Get(x =>
                x.Id == id &&
                x.UserId == userId &&
                x.DeletedAt == null
            );

            if (drill == null)
                return new ErrorDataResult<PTextDrill?>(null, "Drill not found.");

            return new SuccessDataResult<PTextDrill?>(drill);
        }

        public IDataResult<List<PTextDrill>> GetList()
        {
            var list = _dao
                .GetAll(x => x.DeletedAt == null)
                .ToList();

            return new SuccessDataResult<List<PTextDrill>>(list);
        }

        public IDataResult<List<PTextDrill>> GetByUser(int userId)
        {
            var list = _dao
                .GetAll(x => x.UserId == userId && x.DeletedAt == null)
                .ToList();

            return new SuccessDataResult<List<PTextDrill>>(list);
        }

        public IDataResult<PTextDrill> Add(PTextDrill drill)
        {
            if (string.IsNullOrWhiteSpace(drill.Name))
                drill.Name = "Pre Text Drill";

            drill.CreatedAt = DateTime.UtcNow;
            drill.UpdatedAt = DateTime.UtcNow;
            drill.DeletedAt = null;

            _dao.Add(drill);

            return new SuccessDataResult<PTextDrill>(
                drill,
                "Pre text drill created successfully."
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

        public IResult Update(PTextDrill drill)
        {
            var existing = _dao.Get(x => x.Id == drill.Id && x.DeletedAt == null);
            if (existing == null)
                return new ErrorResult("Drill not found.");

            drill.UpdatedAt = DateTime.UtcNow;
            _dao.Update(drill);

            return new SuccessResult("Pre Text drill updated.");
        }

        public IResult Delete(int id)
        {
            var drill = _dao.Get(x => x.Id == id && x.DeletedAt == null);
            if (drill == null)
                return new ErrorResult("Drill not found.");

            drill.DeletedAt = DateTime.UtcNow;
            drill.UpdatedAt = DateTime.UtcNow;
            _dao.Update(drill);

            return new SuccessResult("Pre Text drill deleted.");
        }
    }
}
