using Microsoft.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;

namespace Business
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            // User
            services.AddScoped<IUserService, UserService>();

            // Colors
            services.AddScoped<IDrillColorService, DrillColorService>();

            // Custom drills
            services.AddScoped<ICColorDrillService, CColorDrillService>();
            services.AddScoped<ICSoundDrillService, CSoundDrillService>();
            services.AddScoped<ICTextDrillService, CTextDrillService>();
            services.AddScoped<ICFocusDrillService, CFocusDrillService>();
            services.AddScoped<ICCombDrillService, CCombDrillService>();

            // Predefined drills
            services.AddScoped<IP4ColorDrillService, P4ColorDrillService>();
            services.AddScoped<IPSoundDrillService, PSoundDrillService>();
            services.AddScoped<IPTextDrillService, PTextDrillService>();
            services.AddScoped<IPFocusDrillService, PFocusDrillService>();
            services.AddScoped<IPCombDrillService, PCombDrillService>();

            return services;
        }
    }
}
