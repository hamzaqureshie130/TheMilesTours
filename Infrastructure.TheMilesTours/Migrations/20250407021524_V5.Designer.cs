﻿// <auto-generated />
using System;
using Infrastructure.TheMilesTours.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.TheMilesTours.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250407021524_V5")]
    partial class V5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DomainLayer.TheMilesTours.Entities.Gallery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TourId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.ToTable("Gallery");
                });

            modelBuilder.Entity("DomainLayer.TheMilesTours.Entities.Tour", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActivityType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiscountPercentage")
                        .HasColumnType("int");

                    b.Property<string>("GoogleMapUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasDiscout")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OverView")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PricePerPerson")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("StayDuration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TourAttraction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TourEquipement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tour");
                });

            modelBuilder.Entity("DomainLayer.TheMilesTours.Entities.TourPackage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdditionalPrices")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartureLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PriceDoesNotInclude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PriceIncludes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReturnLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TourId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TourId")
                        .IsUnique();

                    b.ToTable("TourPackage");
                });

            modelBuilder.Entity("DomainLayer.TheMilesTours.Entities.TourPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DayNumber")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TourId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.ToTable("TourPlan");
                });

            modelBuilder.Entity("DomainLayer.TheMilesTours.Entities.Gallery", b =>
                {
                    b.HasOne("DomainLayer.TheMilesTours.Entities.Tour", "Tour")
                        .WithMany("GalleryImages")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("DomainLayer.TheMilesTours.Entities.TourPackage", b =>
                {
                    b.HasOne("DomainLayer.TheMilesTours.Entities.Tour", "Tour")
                        .WithOne("TourPackage")
                        .HasForeignKey("DomainLayer.TheMilesTours.Entities.TourPackage", "TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("DomainLayer.TheMilesTours.Entities.TourPlan", b =>
                {
                    b.HasOne("DomainLayer.TheMilesTours.Entities.Tour", "Tour")
                        .WithMany("TourPlan")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("DomainLayer.TheMilesTours.Entities.Tour", b =>
                {
                    b.Navigation("GalleryImages");

                    b.Navigation("TourPackage");

                    b.Navigation("TourPlan");
                });
#pragma warning restore 612, 618
        }
    }
}
