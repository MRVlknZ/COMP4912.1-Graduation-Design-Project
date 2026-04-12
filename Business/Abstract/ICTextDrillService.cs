using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Data.Models;

namespace Business.Abstract
{
    public interface ICTextDrillService
    {
        IDataResult<CTextDrill?> Get(int id);

        IDataResult<CTextDrill?> GetForUser(int id, int userId);

        IDataResult<List<CTextDrill>> GetList();

        IDataResult<List<CTextDrill>> GetByUser(int userId);

        IDataResult<CTextDrill> Add(CTextDrill drill);

        IResult SoftDelete(int id);
        IResult Update(CTextDrill drill);
        IResult Delete(int id);
    }
}
