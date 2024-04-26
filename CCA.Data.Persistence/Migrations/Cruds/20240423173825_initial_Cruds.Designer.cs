﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using CCA.Data.Persistence.Config.DbContexts;

#nullable disable

namespace CCA.Data.Persistence.Migrations.Cruds
{
  [DbContext(typeof(CrudContext))]
    [Migration("20240423173825_initial_Cruds")]
    partial class initial_Cruds
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ZZ.Core.Domain.Models.Cruds.Repo.CrudEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cruds");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CreatedBy = "",
                            CreatedDate = new DateTime(2024, 4, 23, 12, 38, 24, 399, DateTimeKind.Local).AddTicks(7866),
                            Department = "Industrial",
                            Name = "Handcrafted Cotton Chips"
                        },
                        new
                        {
                            Id = -2,
                            CreatedBy = "",
                            CreatedDate = new DateTime(2024, 4, 23, 12, 38, 24, 399, DateTimeKind.Local).AddTicks(8213),
                            Department = "Books & Industrial",
                            Name = "Handcrafted Rubber Cheese"
                        },
                        new
                        {
                            Id = -3,
                            CreatedBy = "",
                            CreatedDate = new DateTime(2024, 4, 23, 12, 38, 24, 399, DateTimeKind.Local).AddTicks(8300),
                            Department = "Health",
                            Name = "Practical Granite Pants"
                        },
                        new
                        {
                            Id = -4,
                            CreatedBy = "",
                            CreatedDate = new DateTime(2024, 4, 23, 12, 38, 24, 399, DateTimeKind.Local).AddTicks(8331),
                            Department = "Music, Health & Beauty",
                            Name = "Refined Soft Soap"
                        },
                        new
                        {
                            Id = -5,
                            CreatedBy = "",
                            CreatedDate = new DateTime(2024, 4, 23, 12, 38, 24, 399, DateTimeKind.Local).AddTicks(8391),
                            Department = "Movies & Jewelery",
                            Name = "Incredible Soft Car"
                        },
                        new
                        {
                            Id = -6,
                            CreatedBy = "",
                            CreatedDate = new DateTime(2024, 4, 23, 12, 38, 24, 399, DateTimeKind.Local).AddTicks(8429),
                            Department = "Health & Computers",
                            Name = "Practical Plastic Gloves"
                        },
                        new
                        {
                            Id = -7,
                            CreatedBy = "",
                            CreatedDate = new DateTime(2024, 4, 23, 12, 38, 24, 399, DateTimeKind.Local).AddTicks(8515),
                            Department = "Electronics",
                            Name = "Licensed Plastic Chicken"
                        },
                        new
                        {
                            Id = -8,
                            CreatedBy = "",
                            CreatedDate = new DateTime(2024, 4, 23, 12, 38, 24, 399, DateTimeKind.Local).AddTicks(8546),
                            Department = "Kids & Industrial",
                            Name = "Awesome Soft Keyboard"
                        },
                        new
                        {
                            Id = -9,
                            CreatedBy = "",
                            CreatedDate = new DateTime(2024, 4, 23, 12, 38, 24, 399, DateTimeKind.Local).AddTicks(8581),
                            Department = "Games",
                            Name = "Unbranded Concrete Chair"
                        },
                        new
                        {
                            Id = -10,
                            CreatedBy = "",
                            CreatedDate = new DateTime(2024, 4, 23, 12, 38, 24, 399, DateTimeKind.Local).AddTicks(8607),
                            Department = "Home & Jewelery",
                            Name = "Unbranded Granite Fish"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
