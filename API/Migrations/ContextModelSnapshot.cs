﻿// <auto-generated />
using Inftastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace API.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Inftastructure.Bom", b =>
                {
                    b.Property<string>("BomCode")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ParentProductCode");

                    b.Property<string>("ProductCode")
                        .IsRequired();

                    b.Property<double>("Quantity");

                    b.HasKey("BomCode");

                    b.HasIndex("ParentProductCode");

                    b.HasIndex("ProductCode");

                    b.ToTable("Boms");
                });

            modelBuilder.Entity("Inftastructure.Entities.Product", b =>
                {
                    b.Property<string>("ProductCode")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BomCode");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("SupplierCode");

                    b.HasKey("ProductCode");

                    b.HasIndex("BomCode");

                    b.HasIndex("SupplierCode");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Inftastructure.Entities.Supplier", b =>
                {
                    b.Property<string>("SupplierCode")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Details");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("SupplierCode");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Inftastructure.Bom", b =>
                {
                    b.HasOne("Inftastructure.Entities.Product", "ParentProduct")
                        .WithMany()
                        .HasForeignKey("ParentProductCode");

                    b.HasOne("Inftastructure.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Inftastructure.Entities.Product", b =>
                {
                    b.HasOne("Inftastructure.Bom")
                        .WithMany("ChildProducts")
                        .HasForeignKey("BomCode");

                    b.HasOne("Inftastructure.Entities.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierCode");
                });
#pragma warning restore 612, 618
        }
    }
}
