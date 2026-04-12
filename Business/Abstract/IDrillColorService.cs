using Core.Utilities.Result;
using Data.Models;

namespace Business.Abstract
{
    public interface IDrillColorService
    {
        IResult Add(DrillColor color);
        IResult Update(DrillColor color);
        IResult Delete(int id);

        IDataResult<DrillColor?> Get(int id);
        IDataResult<List<DrillColor>> GetList();
    }
}
