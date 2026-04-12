using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Data.Models;

namespace Business.Abstract
{
    public interface IPSoundDrillService
    {
        IDataResult<PSoundDrill?> Get(int id);

        IDataResult<PSoundDrill?> GetForUser(int id, int userId);

        IDataResult<List<PSoundDrill>> GetList();

        IDataResult<List<PSoundDrill>> GetByUser(int userId);

        IDataResult<PSoundDrill> Add(PSoundDrill drill);

        IResult SoftDelete(int id);

        IResult Update(PSoundDrill drill);
        IResult Delete(int id);
    }
}
