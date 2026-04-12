using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Data.Models;

namespace Business.Abstract
{
    public interface IPTextDrillService
    {
        IDataResult<PTextDrill?> Get(int id);

        IDataResult<PTextDrill?> GetForUser(int id, int userId);

        IDataResult<List<PTextDrill>> GetList();

        IDataResult<List<PTextDrill>> GetByUser(int userId);

        IDataResult<PTextDrill> Add(PTextDrill drill);

        IResult SoftDelete(int id);
        IResult Update(PTextDrill drill);
        IResult Delete(int id);
    }
}
