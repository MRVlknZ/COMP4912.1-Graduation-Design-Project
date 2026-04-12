using System.Linq;
using System.Collections.Generic;
using Business.Abstract;
using Access.Abstract;
using Core.Utilities.Result;
using Core.Utilities.Constant;
using Data.Models;

namespace Business.Concrete
{
    public class DrillColorService : IDrillColorService
    {
        private readonly IDrillColorDao _dao;
        public DrillColorService(IDrillColorDao dao) => _dao = dao;

        public IResult Add(DrillColor color)
        {
            _dao.Add(color);
            return new SuccessResult(ResultConstant.RecordCreated);
        }

        public IResult Update(DrillColor color)
        {
            _dao.Update(color);
            return new SuccessResult(ResultConstant.RecordUpdated);
        }

        public IResult Delete(int id)
        {
            var e = _dao.Get(x => x.Id == id);
            if (e == null) return new ErrorResult(ResultConstant.RecordNotFound);
            _dao.Delete(e);
            return new SuccessResult(ResultConstant.RecordDeleted);
        }

        public IDataResult<DrillColor?> Get(int id)
            => new SuccessDataResult<DrillColor?>(_dao.Get(x => x.Id == id));

        public IDataResult<List<DrillColor>> GetList()
            => new SuccessDataResult<List<DrillColor>>(_dao.GetAll().ToList());
    }
}
