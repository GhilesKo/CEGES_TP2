using CEGES_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CEGES_DataAccess.Configurations
{
    public class SeedGroupeConfiguration : IEntityTypeConfiguration<Groupe>
    {
        public void Configure(EntityTypeBuilder<Groupe> builder)
        {
            int id = 0;
            int entrepriseId = 0;

            builder.HasData
            (
                new Groupe
                {
                    Id = ++id,
                    EntrepriseId = ++entrepriseId,
                    Nom = "Restaurant"
                },
                new Groupe
                {
                    Id = ++id,
                    EntrepriseId = entrepriseId,
                    Nom = "Livraison"
                },
                new Groupe
                {
                    Id = ++id,
                    EntrepriseId = ++entrepriseId,
                    Nom = "Baie-Comeau"
                },
                new Groupe
                {
                    Id = ++id,
                    EntrepriseId = entrepriseId,
                    Nom = "Arvida"
                },
                new Groupe
                {
                    Id = ++id,
                    EntrepriseId = entrepriseId,
                    Nom = "Alma"
                },
                new Groupe
                {
                    Id = ++id,
                    EntrepriseId = entrepriseId,
                    Nom = "Kitimat"
                },
                new Groupe
                {
                    Id = ++id,
                    EntrepriseId = entrepriseId,
                    Nom = "Sept-Îles"
                },
                new Groupe
                {
                    Id = ++id,
                    EntrepriseId = entrepriseId,
                    Nom = "Deschambeault"
                }
            );
        }
    }
}
