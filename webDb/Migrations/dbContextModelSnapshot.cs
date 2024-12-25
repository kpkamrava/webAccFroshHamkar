﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webDb;

#nullable disable

namespace webDb.Migrations
{
    [DbContext(typeof(dbContext))]
    partial class dbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webDb.tblSales", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Bed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Bes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double?>("Darsad")
                        .HasColumnType("float");

                    b.Property<string>("Des")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(200)");

                    b.Property<decimal?>("MabFrosh")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MabH")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Mande")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("tblSellerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("tblSellerId");

                    b.ToTable("tblSales");
                });

            modelBuilder.Entity("webDb.tblSeller", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Darsad")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(200)");

                    b.HasKey("Id");

                    b.ToTable("tblSeller");
                });

            modelBuilder.Entity("webDb.tblSales", b =>
                {
                    b.HasOne("webDb.tblSeller", "tblSeller")
                        .WithMany()
                        .HasForeignKey("tblSellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tblSeller");
                });
#pragma warning restore 612, 618
        }
    }
}
