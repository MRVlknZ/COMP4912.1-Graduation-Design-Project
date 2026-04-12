using System;
using System.Linq;
using System.Collections.Generic;
using Business.Abstract;
using Access.Abstract;
using Core.Utilities.Result;
using Data.Models;

namespace Business.Concrete
{
    public class PFocusDrillService : IPFocusDrillService
    {
        private readonly IPFocusDrillDao _dao;

        public PFocusDrillService(IPFocusDrillDao dao)
        {
            _dao = dao;
        }

        public IDataResult<PFocusDrill?> Get(int id)
        {
            var drill = _dao.Get(x => x.Id == id && x.DeletedAt == null);

            if (drill == null)
                return new ErrorDataResult<PFocusDrill?>(null, "Drill not found.");

            return new SuccessDataResult<PFocusDrill?>(drill);
        }

        public IDataResult<PFocusDrill?> GetForUser(int id, int userId)
        {
            var drill = _dao.Get(x =>
                x.Id == id &&
                x.UserId == userId &&
                x.DeletedAt == null
            );

            if (drill == null)
                return new ErrorDataResult<PFocusDrill?>(null, "Drill not found.");

            return new SuccessDataResult<PFocusDrill?>(drill);
        }

        public IDataResult<List<PFocusDrill>> GetList()
        {
            var list = _dao
                .GetAll(x => x.DeletedAt == null)
                .ToList();

            return new SuccessDataResult<List<PFocusDrill>>(list);
        }

        public IDataResult<List<PFocusDrill>> GetByUser(int userId)
        {
            var list = _dao
                .GetAll(x => x.UserId == userId && x.DeletedAt == null)
                .ToList();

            return new SuccessDataResult<List<PFocusDrill>>(list);
        }

        public IDataResult<PFocusDrill> Add(PFocusDrill drill)
        {
            if (string.IsNullOrWhiteSpace(drill.Name))
                drill.Name = "Pre Focus Drill";

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

            return new SuccessDataResult<PFocusDrill>(
                drill,
                "Pre Focus drill created successfully."
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

        public IResult Update(PFocusDrill drill)
        {
            var existing = _dao.Get(x => x.Id == drill.Id && x.DeletedAt == null);
            if (existing == null)
                return new ErrorResult("Drill not found.");

            drill.UpdatedAt = DateTime.UtcNow;
            _dao.Update(drill);

            return new SuccessResult("Pre focus drill updated.");
        }

        public IResult Delete(int id)
        {
            var drill = _dao.Get(x => x.Id == id && x.DeletedAt == null);
            if (drill == null)
                return new ErrorResult("Drill not found.");

            drill.DeletedAt = DateTime.UtcNow;
            drill.UpdatedAt = DateTime.UtcNow;
            _dao.Update(drill);

            return new SuccessResult("Pre focus drill deleted.");
        }
    }
}
