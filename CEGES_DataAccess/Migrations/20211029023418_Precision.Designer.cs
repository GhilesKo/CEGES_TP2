﻿// <auto-generated />
using CEGES_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CEGES_DataAccess.Migrations
{
    [DbContext(typeof(CegesDbContext))]
    [Migration("20211029023418_Precision")]
    partial class Precision
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CEGES_Models.Entreprise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Entreprises");
                });

            modelBuilder.Entity("CEGES_Models.Equipement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupeId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupeId");

                    b.ToTable("Equipement");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Equipement");
                });

            modelBuilder.Entity("CEGES_Models.Groupe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EntrepriseId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EntrepriseId");

                    b.ToTable("Groupes");
                });

            modelBuilder.Entity("CEGES_Models.EquipementConstant", b =>
                {
                    b.HasBaseType("CEGES_Models.Equipement");

                    b.Property<decimal>("Emissions")
                        .HasPrecision(20, 10)
                        .HasColumnType("decimal(20,10)");

                    b.HasDiscriminator().HasValue("EquipementConstant");
                });

            modelBuilder.Entity("CEGES_Models.EquipementLineaire", b =>
                {
                    b.HasBaseType("CEGES_Models.Equipement");

                    b.Property<decimal>("FacteurConversion")
                        .HasPrecision(20, 10)
                        .HasColumnType("decimal(20,10)");

                    b.Property<string>("UniteMesure")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("EquipementLineaire");
                });

            modelBuilder.Entity("CEGES_Models.EquipementRelatif", b =>
                {
                    b.HasBaseType("CEGES_Models.Equipement");

                    b.Property<decimal>("Maximum")
                        .HasPrecision(20, 10)
                        .HasColumnType("decimal(20,10)");

                    b.Property<decimal>("Minimum")
                        .HasPrecision(20, 10)
                        .HasColumnType("decimal(20,10)");

                    b.HasDiscriminator().HasValue("EquipementRelatif");
                });

            modelBuilder.Entity("CEGES_Models.Equipement", b =>
                {
                    b.HasOne("CEGES_Models.Groupe", "Groupe")
                        .WithMany("Equipements")
                        .HasForeignKey("GroupeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Groupe");
                });

            modelBuilder.Entity("CEGES_Models.Groupe", b =>
                {
                    b.HasOne("CEGES_Models.Entreprise", "Entreprise")
                        .WithMany("Groupes")
                        .HasForeignKey("EntrepriseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entreprise");
                });

            modelBuilder.Entity("CEGES_Models.Entreprise", b =>
                {
                    b.Navigation("Groupes");
                });

            modelBuilder.Entity("CEGES_Models.Groupe", b =>
                {
                    b.Navigation("Equipements");
                });
#pragma warning restore 612, 618
        }
    }
}
