using Access.Abstract;
using Access.Contexts;
using Core.DataAccess;
using Data.Models;

namespace Access.Concrete
{
    public class P4ColorDrillDao : EntityRepository<P4ColorDrill, TrainingDbContext>, IP4ColorDrillDao { }
    public class PSoundDrillDao : EntityRepository<PSoundDrill, TrainingDbContext>, IPSoundDrillDao { }
    public class PTextDrillDao : EntityRepository<PTextDrill, TrainingDbContext>, IPTextDrillDao { }
    public class PFocusDrillDao : EntityRepository<PFocusDrill, TrainingDbContext>, IPFocusDrillDao { }
    public class PCombDrillDao : EntityRepository<PCombDrill, TrainingDbContext>, IPCombDrillDao { }
}
