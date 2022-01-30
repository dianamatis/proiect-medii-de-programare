﻿// <auto-generated />
using System;
using Matis_Diana_ProiectExamen.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Matis_Diana_ProiectExamen.Migrations
{
    [DbContext(typeof(Matis_Diana_ProiectExamenContext))]
    [Migration("20220124203038_PhoneCondition")]
    partial class PhoneCondition
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Matis_Diana_ProiectExamen.Models.Brand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Matis_Diana_ProiectExamen.Models.Condition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConditionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Condition");
                });

            modelBuilder.Entity("Matis_Diana_ProiectExamen.Models.Phone", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandID")
                        .HasColumnType("int");

                    b.Property<string>("Capacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LunchDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6, 2)");

                    b.HasKey("ID");

                    b.HasIndex("BrandID");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("Matis_Diana_ProiectExamen.Models.PhoneCondition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConditionID")
                        .HasColumnType("int");

                    b.Property<int>("ConditonID")
                        .HasColumnType("int");

                    b.Property<int>("PhoneID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ConditionID");

                    b.HasIndex("PhoneID");

                    b.ToTable("PhoneCondition");
                });

            modelBuilder.Entity("Matis_Diana_ProiectExamen.Models.Phone", b =>
                {
                    b.HasOne("Matis_Diana_ProiectExamen.Models.Brand", "Brand")
                        .WithMany("Phones")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Matis_Diana_ProiectExamen.Models.PhoneCondition", b =>
                {
                    b.HasOne("Matis_Diana_ProiectExamen.Models.Condition", "Condition")
                        .WithMany("PhoneConditions")
                        .HasForeignKey("ConditionID");

                    b.HasOne("Matis_Diana_ProiectExamen.Models.Phone", "Phone")
                        .WithMany("PhoneConditions")
                        .HasForeignKey("PhoneID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}