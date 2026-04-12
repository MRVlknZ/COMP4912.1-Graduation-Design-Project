using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Data.Models;

namespace Business.Abstract
{
    public interface ICCombDrillService
    {
        IDataResult<CCombDrill?> Get(int id);

        IDataResult<CCombDrill?> GetForUser(int id, int userId);

        IDataResult<List<CCombDrill>> GetList();

        IDataResult<List<CCombDrill>> GetByUser(int userId);

        IDataResult<CCombDrill> Add(CCombDrill drill);

        IResult SoftDelete(int id);
        IResult Update(CCombDrill drill);
        IResult Delete(int id);
    }
}
