﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Onyx.Product.Persistence;

#nullable disable

namespace Onyx.Product.Persistence.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20240815111706_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Onyx.Product.Domain.Entities.Colour", b =>
                {
                    b.Property<Guid>("ColourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ColourId");

                    b.ToTable("Colours");

                    b.HasData(
                        new
                        {
                            ColourId = new Guid("bea9fffd-6c23-44f5-b377-ed7aa6d08c7a"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Red"
                        },
                        new
                        {
                            ColourId = new Guid("e77e6081-e479-48a6-8df7-4b6035b5a912"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Amber"
                        },
                        new
                        {
                            ColourId = new Guid("d896da4c-cb30-4d74-9850-9c963fc5088e"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Green"
                        });
                });

            modelBuilder.Entity("Onyx.Product.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ColourId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProductId");

                    b.HasIndex("ColourId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("08ce4b3e-dde0-4563-86a7-321cd32b30f6"),
                            Amount = 299.99m,
                            ColourId = new Guid("bea9fffd-6c23-44f5-b377-ed7aa6d08c7a"),
                            CreatedBy = "Joe Bloggs",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Trail cycle",
                            Name = "Mountain Bike"
                        },
                        new
                        {
                            ProductId = new Guid("a25ee03f-a1b0-4746-affb-db75e8f10729"),
                            Amount = 499.99m,
                            ColourId = new Guid("e77e6081-e479-48a6-8df7-4b6035b5a912"),
                            CreatedBy = "John Doe",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Racing cycle",
                            Name = "Race Bike"
                        });
                });

            modelBuilder.Entity("Onyx.Product.Domain.Entities.Product", b =>
                {
                    b.HasOne("Onyx.Product.Domain.Entities.Colour", "Colour")
                        .WithMany()
                        .HasForeignKey("ColourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colour");
                });
#pragma warning restore 612, 618
        }
    }
}
