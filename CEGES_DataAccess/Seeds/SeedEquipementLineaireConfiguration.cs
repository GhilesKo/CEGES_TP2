using CEGES_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CEGES_DataAccess.Configurations
{
    public class SeedEquipementLineaireConfiguration : IEntityTypeConfiguration<EquipementLineaire>
    {
        public void Configure(EntityTypeBuilder<EquipementLineaire> builder)
        {
            builder.HasData
            (
                new EquipementLineaire
                {
                    Id = 1,
                    GroupeId = 1,
                    Nom = "Four",
                    UniteMesure = "pizza(s)",
                    FacteurConversion = 0.000143M
                },
                new EquipementLineaire
                {
                    Id = 5,
                    GroupeId = 2,
                    Nom = "Yaris 1",
                    UniteMesure = "km",
                    FacteurConversion = 0.000184M
                },
                new EquipementLineaire
                {
                    Id = 6,
                    GroupeId = 2,
                    Nom = "Yaris 2",
                    UniteMesure = "km",
                    FacteurConversion = 0.000184M
                },
                new EquipementLineaire
                {
                    Id = 7,
                    GroupeId = 2,
                    Nom = "Leaf 1",
                    UniteMesure = "km",
                    FacteurConversion = 0.00000854M
                },
                new EquipementLineaire
                {
                    Id = 8,
                    GroupeId = 2,
                    Nom = "Leaf 2",
                    UniteMesure = "km",
                    FacteurConversion = 0.00000854M
                },
                new EquipementLineaire
                {
                    Id = 9,
                    GroupeId = 2,
                    Nom = "Leaf 3",
                    UniteMesure = "km",
                    FacteurConversion = 0.00000854M
                },
                new EquipementLineaire
                {
                    Id = 10,
                    GroupeId = 3,
                    Nom = "Transport ferroviaire",
                    UniteMesure = "km",
                    FacteurConversion = 0.00098M
                },
                new EquipementLineaire
                {
                    Id = 14,
                    GroupeId = 3,
                    Nom = "Centrale hydroélectrique",
                    UniteMesure = "MWh",
                    FacteurConversion = 0.0987M
                },
                new EquipementLineaire
                {
                    Id = 16,
                    GroupeId = 3,
                    Nom = "Scies",
                    UniteMesure = "unités",
                    FacteurConversion = 0.00048M
                },
                new EquipementLineaire
                {
                    Id = 18,
                    GroupeId = 3,
                    Nom = "Centre de coulée",
                    UniteMesure = "coulées",
                    FacteurConversion = 0.47M
                },
                new EquipementLineaire
                {
                    Id = 21,
                    GroupeId = 3,
                    Nom = "Concasseur",
                    UniteMesure = "t",
                    FacteurConversion = 4.55M
                },
                new EquipementLineaire
                {
                    Id = 26,
                    GroupeId = 4,
                    Nom = "Transport ferroviaire",
                    UniteMesure = "km",
                    FacteurConversion = 0.00098M
                },
                new EquipementLineaire
                {
                    Id = 30,
                    GroupeId = 4,
                    Nom = "Centrale hydroélectrique",
                    UniteMesure = "MWh",
                    FacteurConversion = 0.0987M
                },
                new EquipementLineaire
                {
                    Id = 32,
                    GroupeId = 4,
                    Nom = "Scies",
                    UniteMesure = "unités",
                    FacteurConversion = 0.00048M
                },
                new EquipementLineaire
                {
                    Id = 34,
                    GroupeId = 4,
                    Nom = "Centre de coulée",
                    UniteMesure = "coulées",
                    FacteurConversion = 0.68M
                },
                new EquipementLineaire
                {
                    Id = 40,
                    GroupeId = 5,
                    Nom = "Transport ferroviaire",
                    UniteMesure = "km",
                    FacteurConversion = 0.00098M
                },
                new EquipementLineaire
                {
                    Id = 43,
                    GroupeId = 5,
                    Nom = "Centrale hydroélectrique",
                    UniteMesure = "MWh",
                    FacteurConversion = 0.0987M
                },
                new EquipementLineaire
                {
                    Id = 45,
                    GroupeId = 5,
                    Nom = "Scies",
                    UniteMesure = "unités",
                    FacteurConversion = 0.00087M
                },
                new EquipementLineaire
                {
                    Id = 46,
                    GroupeId = 5,
                    Nom = "Centre de coulée",
                    UniteMesure = "coulées",
                    FacteurConversion = 0.23M
                },
                new EquipementLineaire
                {
                    Id = 48,
                    GroupeId = 5,
                    Nom = "Concasseur",
                    UniteMesure = "t",
                    FacteurConversion = 4.98M
                },
                new EquipementLineaire
                {
                    Id = 52,
                    GroupeId = 6,
                    Nom = "Transport ferroviaire",
                    UniteMesure = "km",
                    FacteurConversion = 0.00098M
                },
                new EquipementLineaire
                {
                    Id = 57,
                    GroupeId = 6,
                    Nom = "Centre de coulée",
                    UniteMesure = "coulées",
                    FacteurConversion = 0.85M
                },
                new EquipementLineaire
                {
                    Id = 59,
                    GroupeId = 6,
                    Nom = "Concasseur",
                    UniteMesure = "t",
                    FacteurConversion = 6.87M
                },
                new EquipementLineaire
                {
                    Id = 63,
                    GroupeId = 7,
                    Nom = "Transport ferroviaire",
                    UniteMesure = "km",
                    FacteurConversion = 0.00098M
                },
                new EquipementLineaire
                {
                    Id = 65,
                    GroupeId = 7,
                    Nom = "Centrale hydroélectrique",
                    UniteMesure = "MWh",
                    FacteurConversion = 0.124M
                },
                new EquipementLineaire
                {
                    Id = 67,
                    GroupeId = 7,
                    Nom = "Centre de coulée",
                    UniteMesure = "coulées",
                    FacteurConversion = 0.87M
                },
                new EquipementLineaire
                {
                    Id = 70,
                    GroupeId = 7,
                    Nom = "Concasseur",
                    UniteMesure = "t",
                    FacteurConversion = 3.98M
                },
                new EquipementLineaire
                {
                    Id = 74,
                    GroupeId = 8,
                    Nom = "Transport ferroviaire",
                    UniteMesure = "km",
                    FacteurConversion = 0.00098M
                },
                new EquipementLineaire
                {
                    Id = 78,
                    GroupeId = 8,
                    Nom = "Scies",
                    UniteMesure = "unités",
                    FacteurConversion = 0.00034M
                },
                new EquipementLineaire
                {
                    Id = 80,
                    GroupeId = 8,
                    Nom = "Centre de coulée",
                    UniteMesure = "coulées",
                    FacteurConversion = 0.68M
                }
            );
        }
    }
}
