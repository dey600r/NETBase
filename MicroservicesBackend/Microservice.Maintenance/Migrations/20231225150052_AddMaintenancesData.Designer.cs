﻿// <auto-generated />
using System;
using Microservice.MaintenanceApi.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Microservice.MaintenanceApi.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20231225150052_AddMaintenancesData")]
    partial class AddMaintenancesData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microservice.MaintenanceApi.Infraestructure.Entities.Configuration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Master")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Configurations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUser = "UserUnknown",
                            Description = "PRODUCTION_SETUP",
                            Master = true,
                            Name = "PRODUCTION"
                        });
                });

            modelBuilder.Entity("Microservice.MaintenanceApi.Infraestructure.Entities.ConfigurationMaintenance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConfigurationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaintenanceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConfigurationId");

                    b.HasIndex("MaintenanceId");

                    b.ToTable("ConfigurationMaintenance");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConfigurationId = 1,
                            CreatedDate = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUser = "UserUnknown",
                            MaintenanceId = 1
                        },
                        new
                        {
                            Id = 2,
                            ConfigurationId = 1,
                            CreatedDate = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUser = "UserUnknown",
                            MaintenanceId = 2
                        });
                });

            modelBuilder.Entity("Microservice.MaintenanceApi.Infraestructure.Entities.Maintenance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FromKm")
                        .HasColumnType("int");

                    b.Property<bool>("Init")
                        .HasColumnType("bit");

                    b.Property<int>("Km")
                        .HasColumnType("int");

                    b.Property<int>("MaintenanceFreqId")
                        .HasColumnType("int");

                    b.Property<bool>("Master")
                        .HasColumnType("bit");

                    b.Property<int?>("Time")
                        .HasColumnType("int");

                    b.Property<int>("ToKm")
                        .HasColumnType("int");

                    b.Property<bool>("Wear")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MaintenanceFreqId");

                    b.ToTable("Maintenance");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUser = "UserUnknown",
                            Description = "FIRST_REVIEW",
                            FromKm = 0,
                            Init = true,
                            Km = 1000,
                            MaintenanceFreqId = 1,
                            Master = true,
                            Time = 6,
                            ToKm = 0,
                            Wear = false
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUser = "UserUnknown",
                            Description = "CHANGE_WHEEL",
                            FromKm = 0,
                            Init = false,
                            Km = 30000,
                            MaintenanceFreqId = 2,
                            Master = true,
                            Time = 36,
                            ToKm = 0,
                            Wear = true
                        });
                });

            modelBuilder.Entity("Microservice.MaintenanceApi.Infraestructure.Entities.MaintenanceElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Master")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MaintenanceElement");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUser = "UserUnknown",
                            Description = "CHANGE_FRONT_WHEEL",
                            Master = true,
                            Name = "FRONT_WHEEL"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUser = "UserUnknown",
                            Description = "CHANGE_BACK_WHEEL",
                            Master = true,
                            Name = "BACK_WHEEL"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUser = "UserUnknown",
                            Description = "CHANGE_ENGINE_OIL",
                            Master = true,
                            Name = "ENGINE_OIL"
                        });
                });

            modelBuilder.Entity("Microservice.MaintenanceApi.Infraestructure.Entities.MaintenanceFreq", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MaintenanceFreq");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "O",
                            CreatedDate = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUser = "UserUnknown",
                            Description = "ONCE"
                        },
                        new
                        {
                            Id = 2,
                            Code = "C",
                            CreatedDate = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUser = "UserUnknown",
                            Description = "CALENDAR"
                        });
                });

            modelBuilder.Entity("Microservice.MaintenanceApi.Infraestructure.Entities.MaintenanceMaintenanceElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaintenanceElementId")
                        .HasColumnType("int");

                    b.Property<int>("MaintenanceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaintenanceElementId");

                    b.HasIndex("MaintenanceId");

                    b.ToTable("MaintenanceMaintenanceElement");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUser = "UserUnknown",
                            MaintenanceElementId = 3,
                            MaintenanceId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUser = "UserUnknown",
                            MaintenanceElementId = 1,
                            MaintenanceId = 2
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUser = "UserUnknown",
                            MaintenanceElementId = 3,
                            MaintenanceId = 2
                        });
                });

            modelBuilder.Entity("Microservice.MaintenanceApi.Infraestructure.Entities.ConfigurationMaintenance", b =>
                {
                    b.HasOne("Microservice.MaintenanceApi.Infraestructure.Entities.Configuration", "Configuration")
                        .WithMany("ConfigurationMaintenances")
                        .HasForeignKey("ConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microservice.MaintenanceApi.Infraestructure.Entities.Maintenance", "Maintenance")
                        .WithMany("ConfigurationMaintenances")
                        .HasForeignKey("MaintenanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Configuration");

                    b.Navigation("Maintenance");
                });

            modelBuilder.Entity("Microservice.MaintenanceApi.Infraestructure.Entities.Maintenance", b =>
                {
                    b.HasOne("Microservice.MaintenanceApi.Infraestructure.Entities.MaintenanceFreq", "MaintenanceFreq")
                        .WithMany("Maintenances")
                        .HasForeignKey("MaintenanceFreqId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaintenanceFreq");
                });

            modelBuilder.Entity("Microservice.MaintenanceApi.Infraestructure.Entities.MaintenanceMaintenanceElement", b =>
                {
                    b.HasOne("Microservice.MaintenanceApi.Infraestructure.Entities.MaintenanceElement", "MaintenanceElement")
                        .WithMany("MaintenanceMaintenanceElements")
                        .HasForeignKey("MaintenanceElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microservice.MaintenanceApi.Infraestructure.Entities.Maintenance", "Maintenance")
                        .WithMany("MaintenanceMaintenanceElements")
                        .HasForeignKey("MaintenanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Maintenance");

                    b.Navigation("MaintenanceElement");
                });

            modelBuilder.Entity("Microservice.MaintenanceApi.Infraestructure.Entities.Configuration", b =>
                {
                    b.Navigation("ConfigurationMaintenances");
                });

            modelBuilder.Entity("Microservice.MaintenanceApi.Infraestructure.Entities.Maintenance", b =>
                {
                    b.Navigation("ConfigurationMaintenances");

                    b.Navigation("MaintenanceMaintenanceElements");
                });

            modelBuilder.Entity("Microservice.MaintenanceApi.Infraestructure.Entities.MaintenanceElement", b =>
                {
                    b.Navigation("MaintenanceMaintenanceElements");
                });

            modelBuilder.Entity("Microservice.MaintenanceApi.Infraestructure.Entities.MaintenanceFreq", b =>
                {
                    b.Navigation("Maintenances");
                });
#pragma warning restore 612, 618
        }
    }
}