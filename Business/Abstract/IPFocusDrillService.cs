using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Access.Abstract;
using Business.Concrete;
using Core.Utilities.Result;
using Data.Models;

namespace Business.Abstract
{
    public interface IPFocusDrillService
    {
        IDataResult<PFocusDrill?> Get(int id);

        IDataResult<PFocusDrill?> GetForUser(int id, int userId);

        IDataResult<List<PFocusDrill>> GetList();

        IDataResult<List<PFocusDrill>> GetByUser(int userId);

        IDataResult<PFocusDrill> Add(PFocusDrill drill);

        IResult SoftDelete(int id);
        IResult Update(PFocusDrill drill);
        IResult Delete(int id);
    }
}
