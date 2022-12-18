using CEGES_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CEGES_DataAccess.Configurations
{
    public class SeedEntrepriseConfiguration : IEntityTypeConfiguration<Entreprise>
    {
        public void Configure(EntityTypeBuilder<Entreprise> builder)
        {
            builder.HasData
            (
                new Entreprise
                {
                    Id = 1,
                    Nom = "Pizza Pizza"
                },

                new Entreprise
                {
                    Id = 2,
                    Nom = "Aluminium du Québec"
                }
            ) ;
        }
    }
}
