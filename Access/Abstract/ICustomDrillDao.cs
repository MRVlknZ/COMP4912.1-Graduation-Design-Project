using System;
using Core.DataAccess;
using Data.Models;

namespace Access.Abstract
{
    public interface ICColorDrillDao : IEntityRepository<CColorDrill> { }
    public interface ICSoundDrillDao : IEntityRepository<CSoundDrill> { }
    public interface ICTextDrillDao : IEntityRepository<CTextDrill> { }
    public interface ICFocusDrillDao : IEntityRepository<CFocusDrill> { }
    public interface ICCombDrillDao : IEntityRepository<CCombDrill> { }
}


