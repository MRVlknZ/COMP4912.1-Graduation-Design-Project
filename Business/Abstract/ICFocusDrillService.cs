using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Data.Models;

namespace Business.Abstract
{
    public interface ICFocusDrillService
    {
        IDataResult<CFocusDrill?> Get(int id);

        IDataResult<CFocusDrill?> GetForUser(int id, int userId);

        IDataResult<List<CFocusDrill>> GetList();

        IDataResult<List<CFocusDrill>> GetByUser(int userId);

        IDataResult<CFocusDrill> Add(CFocusDrill drill);

        IResult SoftDelete(int id);
        IResult Update(CFocusDrill drill);
        IResult Delete(int id);
    }
}
