using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Data.Models;

namespace Business.Abstract
{
    public interface IP4ColorDrillService
    {
        IDataResult<P4ColorDrill?> Get(int id);

        IDataResult<P4ColorDrill?> GetForUser(int id, int userId);

        IDataResult<List<P4ColorDrill>> GetList();

        IDataResult<List<P4ColorDrill>> GetByUser(int userId);

        IDataResult<P4ColorDrill> Add(P4ColorDrill drill);

        IResult SoftDelete(int id);
        IResult Update(P4ColorDrill drill);
        IResult Delete(int id);
    }
}
