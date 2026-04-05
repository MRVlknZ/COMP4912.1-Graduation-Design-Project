using Core.DataAccess;
using Data.Models;

namespace Access.Abstract
{
    public interface IP4ColorDrillDao : IEntityRepository<P4ColorDrill> { }
    public interface IPSoundDrillDao : IEntityRepository<PSoundDrill> { }
    public interface IPTextDrillDao : IEntityRepository<PTextDrill> { }
    public interface IPFocusDrillDao : IEntityRepository<PFocusDrill> { }
    public interface IPCombDrillDao : IEntityRepository<PCombDrill> { }
}
