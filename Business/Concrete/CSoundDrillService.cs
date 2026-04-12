using System.Linq;
using System.Collections.Generic;
using Business.Abstract;
using Access.Abstract;
using Core.Utilities.Result;
using Core.Utilities.Constant;
using Data.Models;

namespace Business.Concrete
{
    public class CSoundDrillService : ICSoundDrillService
    {
        private readonly ICSoundDrillDao _dao;

        public CSoundDrillService(ICSoundDrillDao dao)
        {
            _dao = dao;
        }

        public IDataResult<CSoundDrill?> Get(int id)
        {
            var drill = _dao.Get(x => x.Id == id && x.DeletedAt == null);

            if (drill == null)
                return new ErrorDataResult<CSoundDrill?>(null, "Drill not found.");

            return new SuccessDataResult<CSoundDrill?>(drill);
        }

        public IDataResult<CSoundDrill?> GetForUser(int id, int userId)
        {
            var drill = _dao.Get(x =>
                x.Id == id &&
                x.UserId == userId &&
                x.DeletedAt == null
            );

            if (drill == null)
                return new ErrorDataResult<CSoundDrill?>(null, "Drill not found.");

            return new SuccessDataResult<CSoundDrill?>(drill);
        }

        public IDataResult<List<CSoundDrill>> GetList()
        {
            var list = _dao
                .GetAll(x => x.DeletedAt == null)
                .ToList();

            return new SuccessDataResult<List<CSoundDrill>>(list);
        }

        public IDataResult<List<CSoundDrill>> GetByUser(int userId)
        {
            var list = _dao
                .GetAll(x => x.UserId == userId && x.DeletedAt == null)
                .ToList();

            return new SuccessDataResult<List<CSoundDrill>>(list);
        }

        public IDataResult<CSoundDrill> Add(CSoundDrill drill)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(drill.Name))
                    drill.Name = "Custom Sound Drill";

                switch (drill.DifficultyLevel)
                {
                    case "Easy": drill.IsRandomOrder = false; break;
                    case "Medium":
                    case "Hard": drill.IsRandomOrder = true; break;
                }

                drill.CreatedAt = DateTime.UtcNow;
                drill.UpdatedAt = DateTime.UtcNow;
                drill.DeletedAt = null;

                _dao.Add(drill);

                return new SuccessDataResult<CSoundDrill>(drill, "Custom sound drill created successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<CSoundDrill>(null!, "DB_ERROR: " + ex.Message);
            }
        }

        public IResult SoftDelete(int id)
        {
            var drill = _dao.Get(x => x.Id == id && x.DeletedAt == null);
            if (drill == null)
                return new ErrorResult("Drill not found.");

            drill.DeletedAt = DateTime.UtcNow;
            drill.UpdatedAt = DateTime.UtcNow;

            _dao.Update(drill);

            return new SuccessResult("Custom sound drill soft deleted.");
        }
        public IResult Update(CSoundDrill drill)
        {
            var existing = _dao.Get(x => x.Id == drill.Id && x.DeletedAt == null);
            if (existing == null)
                return new ErrorResult("Drill not found.");

            drill.UpdatedAt = DateTime.UtcNow;
            _dao.Update(drill);

            return new SuccessResult("Custom sound drill updated.");
        }

        public IResult Delete(int id)
        {
            var drill = _dao.Get(x => x.Id == id && x.DeletedAt == null);
            if (drill == null)
                return new ErrorResult("Drill not found.");

            drill.DeletedAt = DateTime.UtcNow;
            drill.UpdatedAt = DateTime.UtcNow;
            _dao.Update(drill);

            return new SuccessResult("Custom sound drill deleted.");
        }
    }
}
