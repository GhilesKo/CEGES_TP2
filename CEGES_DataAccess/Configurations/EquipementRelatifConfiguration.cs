using CEGES_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CEGES_DataAccess.Configurations
{
    public class EquipementRelatifConfiguration : IEntityTypeConfiguration<EquipementRelatif>
    {
        public void Configure(EntityTypeBuilder<EquipementRelatif> builder)
        {
            builder.Property(e => e.Minimum).HasPrecision(20, 10);
            builder.Property(e => e.Maximum).HasPrecision(20, 10);
        }
    }
}
