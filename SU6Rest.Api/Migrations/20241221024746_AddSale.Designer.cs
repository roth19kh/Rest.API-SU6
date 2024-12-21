﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SU6Rest.Api.Date;

#nullable disable

namespace SU6Rest.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241221024746_AddSale")]
    partial class AddSale
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SU6Rest.Api.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categopry");
                });

            modelBuilder.Entity("SU6Rest.Api.Models.Customer", b =>
                {
                    b.Property<Guid>("CusotmerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("CusotmerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("SU6Rest.Api.Models.Item", b =>
                {
                    b.Property<Guid>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsStock")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Qty")
                        .HasColumnType("integer");

                    b.HasKey("ItemId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("SU6Rest.Api.Models.Sale", b =>
                {
                    b.Property<Guid>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<int>("Discount")
                        .HasColumnType("integer");

                    b.Property<double>("GrandTotal")
                        .HasColumnType("double precision");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.Property<DateTime?>("IssueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Total")
                        .HasColumnType("double precision");

                    b.HasKey("SaleId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("SU6Rest.Api.Models.SaleDetail", b =>
                {
                    b.Property<Guid>("SaleDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uuid");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Qty")
                        .HasColumnType("integer");

                    b.Property<Guid>("SaleId")
                        .HasColumnType("uuid");

                    b.Property<double>("Total")
                        .HasColumnType("double precision");

                    b.HasKey("SaleDetailId");

                    b.HasIndex("ItemId");

                    b.HasIndex("SaleId");

                    b.ToTable("SaleDetail");
                });

            modelBuilder.Entity("SU6Rest.Api.Models.Item", b =>
                {
                    b.HasOne("SU6Rest.Api.Models.Category", null)
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SU6Rest.Api.Models.Sale", b =>
                {
                    b.HasOne("SU6Rest.Api.Models.Category", null)
                        .WithMany("Sales")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("SU6Rest.Api.Models.SaleDetail", b =>
                {
                    b.HasOne("SU6Rest.Api.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SU6Rest.Api.Models.Sale", null)
                        .WithMany("SaleDetails")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("SU6Rest.Api.Models.Category", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("SU6Rest.Api.Models.Sale", b =>
                {
                    b.Navigation("SaleDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
