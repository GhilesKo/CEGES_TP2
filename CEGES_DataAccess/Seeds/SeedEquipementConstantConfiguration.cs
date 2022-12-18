using CEGES_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CEGES_DataAccess.Configurations
{
    public class SeedEquipementConstantConfiguration : IEntityTypeConfiguration<EquipementConstant>
    {
        public void Configure(EntityTypeBuilder<EquipementConstant> builder)
        {
            builder.HasData
            (
                new EquipementConstant
                {
                    Id = 4,
                    GroupeId = 1,
                    Nom = "Administration",
                    Emissions = 0.0078M
                },
                new EquipementConstant
                {
                    Id = 15,
                    GroupeId = 3,
                    Nom = "Réfection des cuves",
                    Emissions = 0.0154M
                },
                new EquipementConstant
                {
                    Id = 19,
                    GroupeId = 3,
                    Nom = "Cuves à débrasquer",
                    Emissions = 1.25M
                },
                new EquipementConstant
                {
                    Id = 20,
                    GroupeId = 3,
                    Nom = "Moulage et refroisissement",
                    Emissions = 0.59M
                },
                new EquipementConstant
                {
                    Id = 31,
                    GroupeId = 4,
                    Nom = "Réfection des cuves",
                    Emissions = 0.862M
                },
                new EquipementConstant
                {
                    Id = 35,
                    GroupeId = 4,
                    Nom = "Cuves à débrasquer",
                    Emissions = 2.54M
                },
                new EquipementConstant
                {
                    Id = 44,
                    GroupeId = 5,
                    Nom = "Réfection des cuves",
                    Emissions = 0.037M
                },
                new EquipementConstant
                {
                    Id = 47,
                    GroupeId = 5,
                    Nom = "Cuves à débrasquer",
                    Emissions = 1.98M
                },
                new EquipementConstant
                {
                    Id = 58,
                    GroupeId = 6,
                    Nom = "Moulage et refroisissement",
                    Emissions = 0.74M
                },
                new EquipementConstant
                {
                    Id = 66,
                    GroupeId = 7,
                    Nom = "Réfection des cuves",
                    Emissions = 1.24M
                },
                new EquipementConstant
                {
                    Id = 68,
                    GroupeId = 7,
                    Nom = "Cuves à débrasquer",
                    Emissions = 8.66M
                },
                new EquipementConstant
                {
                    Id = 69,
                    GroupeId = 7,
                    Nom = "Moulage et refroisissement",
                    Emissions = 1.54M
                },
                new EquipementConstant
                {
                    Id = 77,
                    GroupeId = 8,
                    Nom = "Réfection des cuves",
                    Emissions = 0.0014M
                },
                new EquipementConstant
                {
                    Id = 81,
                    GroupeId = 8,
                    Nom = "Cuves à débrasquer",
                    Emissions = 0.98M
                },
                new EquipementConstant
                {
                    Id = 82,
                    GroupeId = 8,
                    Nom = "Moulage et refroisissement",
                    Emissions = 0.547M
                }
            );
        }
    }
}
