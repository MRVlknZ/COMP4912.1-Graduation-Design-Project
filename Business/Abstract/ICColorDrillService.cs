using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Data.Models;

namespace Business.Abstract
{
    public interface ICColorDrillService
    {
        IDataResult<CColorDrill> Add(CColorDrill drill);
        IDataResult<CColorDrill?> Get(int id);
        IDataResult<List<CColorDrill>> GetByUser(int userId);
        IResult Update(CColorDrill drill);
        IResult Delete(int id);
        IResult SoftDelete(int id);
        IDataResult<CColorDrill?> GetForUser(int id, int userId);
    }
}
