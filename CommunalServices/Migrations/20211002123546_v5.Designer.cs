﻿// <auto-generated />
using System;
using CommunalServices.Model.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CommunalServices.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211002123546_v5")]
    partial class v5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CommunalServices.Model.Entities.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float?>("Area")
                        .HasColumnType("real");

                    b.Property<DateTime?>("DateReg")
                        .HasColumnType("datetime2");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float?>("AreaLiving")
                        .HasColumnType("real");

                    b.Property<float?>("AreaMOP")
                        .HasColumnType("real");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("StreetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("StreetId", "Number");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.Measure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Measures");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.NormGigacalorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("NormGigacalories");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.RegistrationValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServiceTypeId")
                        .HasColumnType("int");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("RegistrationValues");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.ServiceHouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("ServiceHouses");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.ServiceProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProviderId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("ServiceProviders");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.ServiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AreaCalc")
                        .HasColumnType("bit");

                    b.Property<int>("MeasureId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("MeasureId");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.Tariff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServiceTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("Tariffs");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.Apartment", b =>
                {
                    b.HasOne("CommunalServices.Model.Entities.House", "House")
                        .WithMany("Apartments")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.House", b =>
                {
                    b.HasOne("CommunalServices.Model.Entities.Street", "Street")
                        .WithMany("Houses")
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Street");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.RegistrationValue", b =>
                {
                    b.HasOne("CommunalServices.Model.Entities.Apartment", "Apartment")
                        .WithMany("RegistrationValues")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommunalServices.Model.Entities.ServiceType", "ServiceType")
                        .WithMany("RegistrationValues")
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartment");

                    b.Navigation("ServiceType");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.ServiceHouse", b =>
                {
                    b.HasOne("CommunalServices.Model.Entities.House", "House")
                        .WithMany("ServiceHouses")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommunalServices.Model.Entities.ServiceType", "ServiceType")
                        .WithMany("ServiceHouses")
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");

                    b.Navigation("ServiceType");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.ServiceProvider", b =>
                {
                    b.HasOne("CommunalServices.Model.Entities.Provider", "Provider")
                        .WithMany("ServiceProviders")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommunalServices.Model.Entities.ServiceType", "ServiceType")
                        .WithMany("ServiceProviders")
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");

                    b.Navigation("ServiceType");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.ServiceType", b =>
                {
                    b.HasOne("CommunalServices.Model.Entities.Measure", "Measure")
                        .WithMany("ServiceTypes")
                        .HasForeignKey("MeasureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Measure");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.Tariff", b =>
                {
                    b.HasOne("CommunalServices.Model.Entities.ServiceType", "ServiceType")
                        .WithMany("Tariffs")
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceType");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.Apartment", b =>
                {
                    b.Navigation("RegistrationValues");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.House", b =>
                {
                    b.Navigation("Apartments");

                    b.Navigation("ServiceHouses");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.Measure", b =>
                {
                    b.Navigation("ServiceTypes");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.Provider", b =>
                {
                    b.Navigation("ServiceProviders");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.ServiceType", b =>
                {
                    b.Navigation("RegistrationValues");

                    b.Navigation("ServiceHouses");

                    b.Navigation("ServiceProviders");

                    b.Navigation("Tariffs");
                });

            modelBuilder.Entity("CommunalServices.Model.Entities.Street", b =>
                {
                    b.Navigation("Houses");
                });
#pragma warning restore 612, 618
        }
    }
}
