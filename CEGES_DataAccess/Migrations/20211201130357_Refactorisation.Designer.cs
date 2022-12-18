﻿// <auto-generated />
using System;
using CEGES_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CEGES_DataAccess.Migrations
{
    [DbContext(typeof(CegesDbContext))]
    [Migration("20211201130357_Refactorisation")]
    partial class Refactorisation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CEGES_Core.Entreprise", b =>
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

            modelBuilder.Entity("CEGES_Core.Equipement", b =>
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

                    b.ToTable("Equipements");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Equipement");
                });

            modelBuilder.Entity("CEGES_Core.Groupe", b =>
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

            modelBuilder.Entity("CEGES_Core.Mesure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EquipementId")
                        .HasColumnType("int");

                    b.Property<int>("PeriodeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valeur")
                        .HasPrecision(20, 10)
                        .HasColumnType("decimal(20,10)");

                    b.HasKey("Id");

                    b.HasIndex("EquipementId");

                    b.HasIndex("PeriodeId");

                    b.ToTable("Mesures");
                });

            modelBuilder.Entity("CEGES_Core.Periode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Debut")
                        .HasColumnType("datetime2");

                    b.Property<int>("EntrepriseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EntrepriseId");

                    b.ToTable("Periodes");
                });

            modelBuilder.Entity("CEGES_Core.EquipementConstant", b =>
                {
                    b.HasBaseType("CEGES_Core.Equipement");

                    b.Property<decimal>("Emissions")
                        .HasPrecision(20, 10)
                        .HasColumnType("decimal(20,10)");

                    b.HasDiscriminator().HasValue("EquipementConstant");
                });

            modelBuilder.Entity("CEGES_Core.EquipementLineaire", b =>
                {
                    b.HasBaseType("CEGES_Core.Equipement");

                    b.Property<decimal>("FacteurConversion")
                        .HasPrecision(20, 10)
                        .HasColumnType("decimal(20,10)");

                    b.Property<string>("UniteMesure")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("EquipementLineaire");
                });

            modelBuilder.Entity("CEGES_Core.EquipementRelatif", b =>
                {
                    b.HasBaseType("CEGES_Core.Equipement");

                    b.Property<decimal>("Maximum")
                        .HasPrecision(20, 10)
                        .HasColumnType("decimal(20,10)");

                    b.Property<decimal>("Minimum")
                        .HasPrecision(20, 10)
                        .HasColumnType("decimal(20,10)");

                    b.HasDiscriminator().HasValue("EquipementRelatif");
                });

            modelBuilder.Entity("CEGES_Core.Equipement", b =>
                {
                    b.HasOne("CEGES_Core.Groupe", "Groupe")
                        .WithMany("Equipements")
                        .HasForeignKey("GroupeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Groupe");
                });

            modelBuilder.Entity("CEGES_Core.Groupe", b =>
                {
                    b.HasOne("CEGES_Core.Entreprise", "Entreprise")
                        .WithMany("Groupes")
                        .HasForeignKey("EntrepriseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entreprise");
                });

            modelBuilder.Entity("CEGES_Core.Mesure", b =>
                {
                    b.HasOne("CEGES_Core.Equipement", "Equipement")
                        .WithMany("Mesures")
                        .HasForeignKey("EquipementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CEGES_Core.Periode", "Periode")
                        .WithMany("Mesures")
                        .HasForeignKey("PeriodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipement");

                    b.Navigation("Periode");
                });

            modelBuilder.Entity("CEGES_Core.Periode", b =>
                {
                    b.HasOne("CEGES_Core.Entreprise", "Entreprise")
                        .WithMany("Periodes")
                        .HasForeignKey("EntrepriseId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Entreprise");
                });

            modelBuilder.Entity("CEGES_Core.Entreprise", b =>
                {
                    b.Navigation("Groupes");

                    b.Navigation("Periodes");
                });

            modelBuilder.Entity("CEGES_Core.Equipement", b =>
                {
                    b.Navigation("Mesures");
                });

            modelBuilder.Entity("CEGES_Core.Groupe", b =>
                {
                    b.Navigation("Equipements");
                });

            modelBuilder.Entity("CEGES_Core.Periode", b =>
                {
                    b.Navigation("Mesures");
                });
#pragma warning restore 612, 618
        }
    }
}
