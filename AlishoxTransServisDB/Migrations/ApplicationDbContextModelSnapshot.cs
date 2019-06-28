﻿// <auto-generated />
using System;
using AlishoxTransServisDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlishoxTransServisDB.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("AlishoxTransServisDB.AutoBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("InsuranceDate");

                    b.Property<DateTime?>("LicenseDate");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.HasKey("Id");

                    b.ToTable("AutoBase");
                });
#pragma warning restore 612, 618
        }
    }
}
