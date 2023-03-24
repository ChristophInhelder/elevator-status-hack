﻿// <auto-generated />
using System;
using Elevator.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Elevator.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("Elevator.Domain.Data.Elevator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ManufacturerName")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("MetaDataSourceInfoId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OpenStreetMapId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OperatorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Properties")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("MetaDataSourceInfoId");

                    b.HasIndex("OperatorId");

                    b.ToTable("Elevators");
                });

            modelBuilder.Entity("Elevator.Domain.Data.GeoLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressText")
                        .HasColumnType("TEXT");

                    b.Property<double>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<double>("Longitude")
                        .HasColumnType("REAL");

                    b.Property<Guid?>("OpenStreetMaPlaceId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GeoLocations");
                });

            modelBuilder.Entity("Elevator.Domain.Data.MetaDataSourceInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("License")
                        .HasColumnType("TEXT");

                    b.Property<string>("SourceType")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MetaDataSourceInfos");
                });

            modelBuilder.Entity("Elevator.Domain.Data.OperationChangeEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ChangedTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ElevatorId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("MetaDataSourceInfoId")
                        .HasColumnType("TEXT");

                    b.Property<string>("OperationMode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ElevatorId");

                    b.HasIndex("MetaDataSourceInfoId");

                    b.ToTable("OperationChangedEvents");
                });

            modelBuilder.Entity("Elevator.Domain.Data.Operator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Operators");
                });

            modelBuilder.Entity("Elevator.Domain.Data.Elevator", b =>
                {
                    b.HasOne("Elevator.Domain.Data.GeoLocation", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("Elevator.Domain.Data.MetaDataSourceInfo", "MetaDataSourceInfo")
                        .WithMany()
                        .HasForeignKey("MetaDataSourceInfoId");

                    b.HasOne("Elevator.Domain.Data.Operator", "Operator")
                        .WithMany()
                        .HasForeignKey("OperatorId");

                    b.Navigation("Location");

                    b.Navigation("MetaDataSourceInfo");

                    b.Navigation("Operator");
                });

            modelBuilder.Entity("Elevator.Domain.Data.OperationChangeEvent", b =>
                {
                    b.HasOne("Elevator.Domain.Data.Elevator", "Elevator")
                        .WithMany("Events")
                        .HasForeignKey("ElevatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Elevator.Domain.Data.MetaDataSourceInfo", "MetaDataSourceInfo")
                        .WithMany()
                        .HasForeignKey("MetaDataSourceInfoId");

                    b.Navigation("Elevator");

                    b.Navigation("MetaDataSourceInfo");
                });

            modelBuilder.Entity("Elevator.Domain.Data.Elevator", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
