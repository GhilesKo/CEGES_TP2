using CEGES_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CEGES_DataAccess.Configurations
{
    public class EquipementConstantConfiguration : IEntityTypeConfiguration<EquipementConstant>
    {
        public void Configure(EntityTypeBuilder<EquipementConstant> builder)
        {
            builder.Property(e => e.Emissions).HasPrecision(20, 10);
        }
    }
}
