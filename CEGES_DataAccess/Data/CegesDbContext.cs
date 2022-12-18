using CEGES_Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CEGES_DataAccess.Data
{
    public class CegesDbContext : IdentityDbContext<ApplicationUser>
    {


        public DbSet<Entreprise> Entreprises { get; set; }
        public DbSet<Groupe> Groupes { get; set; }

        public DbSet<EquipementConstant> EquipementsConstants { get; set; }
        public DbSet<EquipementLineaire> EquipementsLineaires { get; set; }
        public DbSet<EquipementRelatif> EquipementsRelatifs { get; set; }
        public DbSet<Equipement> Equipements { get; set; }

        public DbSet<Mesure> Mesures { get; set; }
        public DbSet<Periode> Periodes { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public CegesDbContext(DbContextOptions<CegesDbContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>()
                .Navigation(e => e.Entreprises).AutoInclude();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CegesDbContext).Assembly);
        }
    }
}
