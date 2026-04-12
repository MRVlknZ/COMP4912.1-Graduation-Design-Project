using System.Linq;
using System.Collections.Generic;
using Business.Abstract;
using Access.Abstract;
using Core.Utilities.Result;
using Data.Models;

namespace Business.Concrete
{
    public class PSoundDrillService : IPSoundDrillService
    {
        private readonly IPSoundDrillDao _dao;

        public PSoundDrillService(IPSoundDrillDao dao)
        {
            _dao = dao;
        }

        public IDataResult<PSoundDrill?> Get(int id)
        {
            var drill = _dao.Get(x => x.Id == id && x.DeletedAt == null);

            if (drill == null)
                return new ErrorDataResult<PSoundDrill?>(null, "Drill not found.");

            return new SuccessDataResult<PSoundDrill?>(drill);
        }

        public IDataResult<PSoundDrill?> GetForUser(int id, int userId)
        {
            var drill = _dao.Get(x =>
                x.Id == id &&
                x.UserId == userId &&
                x.DeletedAt == null
            );

            if (drill == null)
                return new ErrorDataResult<PSoundDrill?>(null, "Drill not found.");

            return new SuccessDataResult<PSoundDrill?>(drill);
        }

        public IDataResult<List<PSoundDrill>> GetList()
        {
            var list = _dao
                .GetAll(x => x.DeletedAt == null)
                .ToList();

            return new SuccessDataResult<List<PSoundDrill>>(list);
        }

        public IDataResult<List<PSoundDrill>> GetByUser(int userId)
        {
            var list = _dao
                .GetAll(x => x.UserId == userId && x.DeletedAt == null)
                .ToList();

            return new SuccessDataResult<List<PSoundDrill>>(list);
        }

        public IDataResult<PSoundDrill> Add(PSoundDrill drill)
        {
            Console.WriteLine(">>> PSoundDrillService.Add HIT <<<");

            try
            {
                if (string.IsNullOrWhiteSpace(drill.Name))
                    drill.Name = "Pre Sound Drill";

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

                return new SuccessDataResult<PSoundDrill>(drill, "Pre sound drill created successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<PSoundDrill>(null!, "DB_ERROR: " + ex.Message);
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

            return new SuccessResult("Pre sound drill soft deleted.");
        }
        public IResult Update(PSoundDrill drill)
        {
            var existing = _dao.Get(x => x.Id == drill.Id && x.DeletedAt == null);
            if (existing == null)
                return new ErrorResult("Drill not found.");

            drill.UpdatedAt = DateTime.UtcNow;
            _dao.Update(drill);

            return new SuccessResult("Pre sound drill updated.");
        }

        public IResult Delete(int id)
        {
            var drill = _dao.Get(x => x.Id == id && x.DeletedAt == null);
            if (drill == null)
                return new ErrorResult("Drill not found.");

            drill.DeletedAt = DateTime.UtcNow;
            drill.UpdatedAt = DateTime.UtcNow;
            _dao.Update(drill);

            return new SuccessResult("Pre sound drill deleted.");
        }
    }
}
