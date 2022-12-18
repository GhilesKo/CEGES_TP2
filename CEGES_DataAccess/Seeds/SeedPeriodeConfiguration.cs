using CEGES_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CEGES_DataAccess.Configurations
{
    public class SeedPeriodeConfiguration : IEntityTypeConfiguration<Periode>
    {
        public void Configure(EntityTypeBuilder<Periode> builder)
        {
            int id = 0;
            builder.HasData
            (
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 1,
                    Debut = new System.DateTime(2020, 7, 1),
                    Fin = new System.DateTime(2020, 7, 1).AddMonths(1).AddDays(-1),
                    Nom = "Juillet 2020"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 1,
                    Debut = new System.DateTime(2020, 8, 1),
                    Fin = new System.DateTime(2020, 8, 1).AddMonths(1).AddDays(-1),
                    Nom = "Août 2020"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 1,
                    Debut = new System.DateTime(2020, 9, 1),
                    Fin = new System.DateTime(2020, 9, 1).AddMonths(1).AddDays(-1),
                    Nom = "Septembre 2020"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 1,
                    Debut = new System.DateTime(2020, 10, 1),
                    Fin = new System.DateTime(2020, 10, 1).AddMonths(1).AddDays(-1),
                    Nom = "Octobre 2020"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 1,
                    Debut = new System.DateTime(2020, 11, 1),
                    Fin = new System.DateTime(2020, 11, 1).AddMonths(1).AddDays(-1),
                    Nom = "Novembre 2020"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 1,
                    Debut = new System.DateTime(2020, 12, 1),
                    Fin = new System.DateTime(2020, 12, 1).AddMonths(1).AddDays(-1),
                    Nom = "Décembre 2020"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 1,
                    Debut = new System.DateTime(2021, 1, 1),
                    Fin = new System.DateTime(2021, 1, 1).AddMonths(1).AddDays(-1),
                    Nom = "Janvier 2021"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 1,
                    Debut = new System.DateTime(2021, 2, 1),
                    Fin = new System.DateTime(2021, 2, 1).AddMonths(1).AddDays(-1),
                    Nom = "Février 2021"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 1,
                    Debut = new System.DateTime(2021, 3, 1),
                    Fin = new System.DateTime(2021, 3, 1).AddMonths(1).AddDays(-1),
                    Nom = "Mars 2021"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 1,
                    Debut = new System.DateTime(2021, 4, 1),
                    Fin = new System.DateTime(2021, 4, 1).AddMonths(1).AddDays(-1),
                    Nom = "Avril 2021"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 1,
                    Debut = new System.DateTime(2021, 5, 1),
                    Fin = new System.DateTime(2021, 5, 1).AddMonths(1).AddDays(-1),
                    Nom = "Mai 2021"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 1,
                    Debut = new System.DateTime(2021, 6, 1),
                    Fin = new System.DateTime(2021, 6, 1).AddMonths(1).AddDays(-1),
                    Nom = "Juin 2021"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 1,
                    Debut = new System.DateTime(2021, 7, 1),
                    Fin = new System.DateTime(2021, 7, 1).AddMonths(1).AddDays(-1),
                    Nom = "Juillet 2021"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 1,
                    Debut = new System.DateTime(2021, 8, 1),
                    Fin = new System.DateTime(2021, 8, 1).AddMonths(1).AddDays(-1),
                    Nom = "Août 2021"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 1,
                    Debut = new System.DateTime(2021, 9, 1),
                    Fin = new System.DateTime(2021, 9, 1).AddMonths(1).AddDays(-1),
                    Nom = "Septembre 2021"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 1,
                    Debut = new System.DateTime(2021, 10, 1),
                    Fin = new System.DateTime(2021, 10, 1).AddMonths(1).AddDays(-1),
                    Nom = "Octobre 2021"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 2,
                    Debut = new System.DateTime(2020, 7, 1),
                    Fin = new System.DateTime(2020, 7, 1).AddMonths(1).AddDays(-1),
                    Nom = "Juillet 2020"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 2,
                    Debut = new System.DateTime(2020, 8, 1),
                    Fin = new System.DateTime(2020, 8, 1).AddMonths(1).AddDays(-1),
                    Nom = "Août 2020"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 2,
                    Debut = new System.DateTime(2020, 9, 1),
                    Fin = new System.DateTime(2020, 9, 1).AddMonths(1).AddDays(-1),
                    Nom = "Septembre 2020"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 2,
                    Debut = new System.DateTime(2020, 10, 1),
                    Fin = new System.DateTime(2020, 10, 1).AddMonths(1).AddDays(-1),
                    Nom = "Octobre 2020"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 2,
                    Debut = new System.DateTime(2020, 11, 1),
                    Fin = new System.DateTime(2020, 11, 1).AddMonths(1).AddDays(-1),
                    Nom = "Novembre 2020"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 2,
                    Debut = new System.DateTime(2020, 12, 1),
                    Fin = new System.DateTime(2020, 12, 1).AddMonths(1).AddDays(-1),
                    Nom = "Décembre 2020"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 2,
                    Debut = new System.DateTime(2021, 1, 1),
                    Fin = new System.DateTime(2021, 1, 1).AddMonths(1).AddDays(-1),
                    Nom = "Janvier 2021"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 2,
                    Debut = new System.DateTime(2021, 2, 1),
                    Fin = new System.DateTime(2021, 2, 1).AddMonths(1).AddDays(-1),
                    Nom = "Février 2021"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 2,
                    Debut = new System.DateTime(2021, 3, 1),
                    Fin = new System.DateTime(2021, 3, 1).AddMonths(1).AddDays(-1),
                    Nom = "Mars 2021"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 2,
                    Debut = new System.DateTime(2021, 4, 1),
                    Fin = new System.DateTime(2021, 4, 1).AddMonths(1).AddDays(-1),
                    Nom = "Avril 2021"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 2,
                    Debut = new System.DateTime(2021, 5, 1),
                    Fin = new System.DateTime(2021, 5, 1).AddMonths(1).AddDays(-1),
                    Nom = "Mai 2021"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 2,
                    Debut = new System.DateTime(2021, 6, 1),
                    Fin = new System.DateTime(2021, 6, 1).AddMonths(1).AddDays(-1),
                    Nom = "Juin 2021"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 2,
                    Debut = new System.DateTime(2021, 7, 1),
                    Fin = new System.DateTime(2021, 7, 1).AddMonths(1).AddDays(-1),
                    Nom = "Juillet 2021"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 2,
                    Debut = new System.DateTime(2021, 8, 1),
                    Fin = new System.DateTime(2021, 8, 1).AddMonths(1).AddDays(-1),
                    Nom = "Août 2021"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 2,
                    Debut = new System.DateTime(2021, 9, 1),
                    Fin = new System.DateTime(2021, 9, 1).AddMonths(1).AddDays(-1),
                    Nom = "Septembre 2021"
                },
                new Periode()
                {
                    Id = ++id,
                    EntrepriseId = 2,
                    Debut = new System.DateTime(2021, 10, 1),
                    Fin = new System.DateTime(2021, 10, 1).AddMonths(1).AddDays(-1),
                    Nom = "Octobre 2021"
                }
            );
        }
    }
}
