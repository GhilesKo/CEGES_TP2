using CEGES_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CEGES_DataAccess.Configurations
{
    public class PeriodeConfiguration : IEntityTypeConfiguration<Periode>
    {
        public void Configure(EntityTypeBuilder<Periode> builder)
        {
            builder.HasOne(p => p.Entreprise)
                .WithMany(e => e.Periodes)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
