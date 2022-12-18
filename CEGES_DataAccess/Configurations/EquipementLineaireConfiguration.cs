using CEGES_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CEGES_DataAccess.Configurations
{
    public class EquipementLineaireConfiguration : IEntityTypeConfiguration<EquipementLineaire>
    {
        public void Configure(EntityTypeBuilder<EquipementLineaire> builder)
        {
            builder.Property(e => e.FacteurConversion).HasPrecision(20, 10);
        }
    }
}
