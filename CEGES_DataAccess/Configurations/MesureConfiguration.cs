using CEGES_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CEGES_DataAccess.Configurations
{
    public class MesureConfiguration : IEntityTypeConfiguration<Mesure>
    {
        public void Configure(EntityTypeBuilder<Mesure> builder)
        {
            builder.Property(e => e.Valeur).HasPrecision(20, 10);
        }
    }
}
