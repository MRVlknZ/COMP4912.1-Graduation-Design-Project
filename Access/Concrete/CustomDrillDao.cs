using Access.Abstract;
using Access.Contexts;
using Core.DataAccess;
using Data.Models;

namespace Access.Concrete
{
    public class CColorDrillDao : EntityRepository<CColorDrill, TrainingDbContext>, ICColorDrillDao { }
    public class CSoundDrillDao : EntityRepository<CSoundDrill, TrainingDbContext>, ICSoundDrillDao { }
    public class CTextDrillDao : EntityRepository<CTextDrill, TrainingDbContext>, ICTextDrillDao { }
    public class CFocusDrillDao : EntityRepository<CFocusDrill, TrainingDbContext>, ICFocusDrillDao { }
    public class CCombDrillDao : EntityRepository<CCombDrill, TrainingDbContext>, ICCombDrillDao { }
}
