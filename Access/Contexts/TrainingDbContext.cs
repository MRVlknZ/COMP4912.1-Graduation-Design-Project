using Microsoft.EntityFrameworkCore;
using Data.Models;

namespace Access.Contexts
{
    public class TrainingDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=MERTVOLKAN\MSSQLSERVER01;Database=SportAppDB4;
                      Trusted_Connection=True;TrustServerCertificate=True;
                      MultipleActiveResultSets=true");
            }
        }

        // Users
        public DbSet<User> Users { get; set; }

        // Colors
        public DbSet<DrillColor> DrillColors { get; set; }

        // Custom drills
        public DbSet<CColorDrill> CColorDrills { get; set; }
        public DbSet<CSoundDrill> CSoundDrills { get; set; }
        public DbSet<CTextDrill> CTextDrills { get; set; }
        public DbSet<CFocusDrill> CFocusDrills { get; set; }
        public DbSet<CCombDrill> CCombDrills { get; set; }

        // Pre drills
        public DbSet<P4ColorDrill> P4ColorDrills { get; set; }
        public DbSet<PSoundDrill> PSoundDrills { get; set; }
        public DbSet<PTextDrill> PTextDrills { get; set; }
        public DbSet<PFocusDrill> PFocusDrills { get; set; }
        public DbSet<PCombDrill> PCombDrills { get; set; }

       
    }
}
