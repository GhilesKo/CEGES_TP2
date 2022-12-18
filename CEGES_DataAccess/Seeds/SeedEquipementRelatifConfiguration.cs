using CEGES_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CEGES_DataAccess.Configurations
{
    public class SeedEquipementRelatifConfiguration : IEntityTypeConfiguration<EquipementRelatif>
    {
        public void Configure(EntityTypeBuilder<EquipementRelatif> builder)
        {
            builder.HasData
            (
                new EquipementRelatif
                {
                    Id = 2,
                    GroupeId = 1,
                    Nom = "Chauffage",
                    Minimum = 1.57M,
                    Maximum = 12.8M
                },
                new EquipementRelatif
                {
                    Id = 3,
                    GroupeId = 1,
                    Nom = "Éclairage",
                    Minimum = 0.85M,
                    Maximum = 1.25M
                },
                new EquipementRelatif
                {
                    Id = 11,
                    GroupeId = 3,
                    Nom = "Calcination",
                    Minimum = 1.54M,
                    Maximum = 6.45M
                },
                new EquipementRelatif
                {
                    Id = 12,
                    GroupeId = 3,
                    Nom = "Fabrication d'anodes",
                    Minimum = 12.98M,
                    Maximum = 400.15M
                },
                new EquipementRelatif
                {
                    Id = 13,
                    GroupeId = 3,
                    Nom = "Four à réduction",
                    Minimum = 8.98M,
                    Maximum = 12.55M
                },
                new EquipementRelatif
                {
                    Id = 17,
                    GroupeId = 3,
                    Nom = "Bain broyé",
                    Minimum = 6.075M,
                    Maximum = 9.73M
                },
                new EquipementRelatif
                {
                    Id = 22,
                    GroupeId = 3,
                    Nom = "Pyroépurateur",
                    Minimum = 53.189M,
                    Maximum = 96.239M
                },
                new EquipementRelatif
                {
                    Id = 23,
                    GroupeId = 3,
                    Nom = "Bains de précipitation",
                    Minimum = 6.007M,
                    Maximum = 9.752M
                },
                new EquipementRelatif
                {
                    Id = 24,
                    GroupeId = 3,
                    Nom = "Broyeur humide",
                    Minimum = 12.317M,
                    Maximum = 22.733M
                },
                new EquipementRelatif
                {
                    Id = 25,
                    GroupeId = 3,
                    Nom = "Filtreurs",
                    Minimum = 1.441M,
                    Maximum = 2.984M
                },
                new EquipementRelatif
                {
                    Id = 27,
                    GroupeId = 4,
                    Nom = "Calcination",
                    Minimum = 3.171M,
                    Maximum = 6.518M
                },
                new EquipementRelatif
                {
                    Id = 28,
                    GroupeId = 4,
                    Nom = "Fabrication d'anodes",
                    Minimum = 35.4M,
                    Maximum = 124.5M
                },
                new EquipementRelatif
                {
                    Id = 29,
                    GroupeId = 4,
                    Nom = "Four à réduction",
                    Minimum = 15.002M,
                    Maximum = 154.81M
                },
                new EquipementRelatif
                {
                    Id = 33,
                    GroupeId = 4,
                    Nom = "Bain broyé",
                    Minimum = 4.775M,
                    Maximum = 11.74M
                },
                new EquipementRelatif
                {
                    Id = 36,
                    GroupeId = 4,
                    Nom = "Pyroépurateur",
                    Minimum = 53.845M,
                    Maximum = 106.448M
                },
                new EquipementRelatif
                {
                    Id = 37,
                    GroupeId = 4,
                    Nom = "Bains de précipitation",
                    Minimum = 5.58M,
                    Maximum = 8.286M
                },
                new EquipementRelatif
                {
                    Id = 38,
                    GroupeId = 4,
                    Nom = "Broyeur humide",
                    Minimum = 10.637M,
                    Maximum = 20.853M
                },
                new EquipementRelatif
                {
                    Id = 39,
                    GroupeId = 4,
                    Nom = "Filtreurs",
                    Minimum = 0.488M,
                    Maximum = 2.575M
                },
                new EquipementRelatif
                {
                    Id = 41,
                    GroupeId = 5,
                    Nom = "Calcination",
                    Minimum = 4.611M,
                    Maximum = 10.226M
                },
                new EquipementRelatif
                {
                    Id = 42,
                    GroupeId = 5,
                    Nom = "Fabrication d'anodes",
                    Minimum = 22.8M,
                    Maximum = 98.4M
                },
                new EquipementRelatif
                {
                    Id = 49,
                    GroupeId = 5,
                    Nom = "Bains de précipitation",
                    Minimum = 4.89M,
                    Maximum = 9.138M
                },
                new EquipementRelatif
                {
                    Id = 50,
                    GroupeId = 5,
                    Nom = "Broyeur humide",
                    Minimum = 10.246M,
                    Maximum = 20.168M
                },
                new EquipementRelatif
                {
                    Id = 51,
                    GroupeId = 5,
                    Nom = "Filtreurs",
                    Minimum = 1.451M,
                    Maximum = 4.879M
                },
                new EquipementRelatif
                {
                    Id = 53,
                    GroupeId = 6,
                    Nom = "Calcination",
                    Minimum = 1.315M,
                    Maximum = 5.317M
                },
                new EquipementRelatif
                {
                    Id = 54,
                    GroupeId = 6,
                    Nom = "Fabrication d'anodes",
                    Minimum = 50.1M,
                    Maximum = 124.54M
                },
                new EquipementRelatif
                {
                    Id = 55,
                    GroupeId = 6,
                    Nom = "Four à réduction",
                    Minimum = 20.215M,
                    Maximum = 138.647M
                },
                new EquipementRelatif
                {
                    Id = 56,
                    GroupeId = 6,
                    Nom = "Bain broyé",
                    Minimum = 4.914M,
                    Maximum = 11.6M
                },
                new EquipementRelatif
                {
                    Id = 60,
                    GroupeId = 6,
                    Nom = "Pyroépurateur",
                    Minimum = 68.506M,
                    Maximum = 90.679M
                },
                new EquipementRelatif
                {
                    Id = 61,
                    GroupeId = 6,
                    Nom = "Bains de précipitation",
                    Minimum = 6.106M,
                    Maximum = 11.053M
                },
                new EquipementRelatif
                {
                    Id = 62,
                    GroupeId = 6,
                    Nom = "Filtreurs",
                    Minimum = 1.439M,
                    Maximum = 3.691M
                },
                new EquipementRelatif
                {
                    Id = 64,
                    GroupeId = 7,
                    Nom = "Calcination",
                    Minimum = 2.359M,
                    Maximum = 7.848M
                },
                new EquipementRelatif
                {
                    Id = 71,
                    GroupeId = 7,
                    Nom = "Bains de précipitation",
                    Minimum = 6.196M,
                    Maximum = 10.667M
                },
                new EquipementRelatif
                {
                    Id = 72,
                    GroupeId = 7,
                    Nom = "Broyeur humide",
                    Minimum = 9.74M,
                    Maximum = 24.073M
                },
                new EquipementRelatif
                {
                    Id = 73,
                    GroupeId = 7,
                    Nom = "Filtreurs",
                    Minimum = 1.228M,
                    Maximum = 2.167M
                },
                new EquipementRelatif
                {
                    Id = 75,
                    GroupeId = 8,
                    Nom = "Fabrication d'anodes",
                    Minimum = 8.45M,
                    Maximum = 16.4M
                },
                new EquipementRelatif
                {
                    Id = 76,
                    GroupeId = 8,
                    Nom = "Four à réduction",
                    Minimum = 28.675M,
                    Maximum = 122.521M
                },
                new EquipementRelatif
                {
                    Id = 79,
                    GroupeId = 8,
                    Nom = "Bain broyé",
                    Minimum = 6.379M,
                    Maximum = 8.03M
                },
                new EquipementRelatif
                {
                    Id = 83,
                    GroupeId = 8,
                    Nom = "Pyroépurateur",
                    Minimum = 50.36M,
                    Maximum = 108.3M
                },
                new EquipementRelatif
                {
                    Id = 84,
                    GroupeId = 8,
                    Nom = "Bains de précipitation",
                    Minimum = 5.215M,
                    Maximum = 7.907M
                },
                new EquipementRelatif
                {
                    Id = 85,
                    GroupeId = 8,
                    Nom = "Broyeur humide",
                    Minimum = 8.98M,
                    Maximum = 24.9M
                },
                new EquipementRelatif
                {
                    Id = 86,
                    GroupeId = 8,
                    Nom = "Filtreurs",
                    Minimum = 1.311M,
                    Maximum = 3.413M
                }
            );
        }
    }
}
