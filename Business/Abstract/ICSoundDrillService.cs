using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Data.Models;

namespace Business.Abstract
{
    public interface ICSoundDrillService
    {
        IDataResult<CSoundDrill?> Get(int id);

        IDataResult<CSoundDrill?> GetForUser(int id, int userId);

        IDataResult<List<CSoundDrill>> GetList();

        IDataResult<List<CSoundDrill>> GetByUser(int userId);

        IDataResult<CSoundDrill> Add(CSoundDrill drill);

        IResult SoftDelete(int id);

        IResult Update(CSoundDrill drill);
        IResult Delete(int id);
    }
}
