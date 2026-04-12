using Autofac;
using Business.Abstract;
using Business.Concrete;
using Access.Abstract;
using Access.Concrete;

namespace Business.AutoFac
{
    public class BusinessAutoFacModule : Module
    {
        protected override void Load(ContainerBuilder b)
        {

            b.RegisterType<UserService>().As<IUserService>();
            b.RegisterType<UserDao>().As<IUserDao>();

            b.RegisterType<DrillColorService>().As<IDrillColorService>();
            b.RegisterType<DrillColorDao>().As<IDrillColorDao>();

            b.RegisterType<CColorDrillService>().As<ICColorDrillService>();
            b.RegisterType<CColorDrillDao>().As<ICColorDrillDao>();

            b.RegisterType<CSoundDrillService>().As<ICSoundDrillService>();
            b.RegisterType<CSoundDrillDao>().As<ICSoundDrillDao>();

            b.RegisterType<CTextDrillService>().As<ICTextDrillService>();
            b.RegisterType<CTextDrillDao>().As<ICTextDrillDao>();

            b.RegisterType<CFocusDrillService>().As<ICFocusDrillService>();
            b.RegisterType<CFocusDrillDao>().As<ICFocusDrillDao>();

            b.RegisterType<CCombDrillService>().As<ICCombDrillService>();
            b.RegisterType<CCombDrillDao>().As<ICCombDrillDao>();

            b.RegisterType<P4ColorDrillService>().As<IP4ColorDrillService>();
            b.RegisterType<P4ColorDrillDao>().As<IP4ColorDrillDao>();

            b.RegisterType<PSoundDrillService>().As<IPSoundDrillService>();
            b.RegisterType<PSoundDrillDao>().As<IPSoundDrillDao>();

            b.RegisterType<PTextDrillService>().As<IPTextDrillService>();
            b.RegisterType<PTextDrillDao>().As<IPTextDrillDao>();

            b.RegisterType<PFocusDrillService>().As<IPFocusDrillService>();
            b.RegisterType<PFocusDrillDao>().As<IPFocusDrillDao>();

            b.RegisterType<PCombDrillService>().As<IPCombDrillService>();
            b.RegisterType<PCombDrillDao>().As<IPCombDrillDao>();
        }
    }
}
