using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Data.Models;

namespace Business.Abstract
{
    public interface IPCombDrillService
    {
        IDataResult<PCombDrill?> Get(int id);

        IDataResult<PCombDrill?> GetForUser(int id, int userId);

        IDataResult<List<PCombDrill>> GetList();

        IDataResult<List<PCombDrill>> GetByUser(int userId);

        IDataResult<PCombDrill> Add(PCombDrill drill);

        IResult SoftDelete(int id);
        IResult Update(PCombDrill drill);
        IResult Delete(int id);
    }
}
