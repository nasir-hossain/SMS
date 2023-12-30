﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SMS.DBContext;

#nullable disable

namespace SMS.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SMS.Models.TblRole", b =>
                {
                    b.Property<long>("IntId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IntId"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("StrRoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IntId");

                    b.ToTable("TblRole");
                });

            modelBuilder.Entity("SMS.Models.TblUser", b =>
                {
                    b.Property<long>("IntId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IntId"), 1L, 1);

                    b.Property<DateTime?>("DteLastActionDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("IntActionBy")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("StrContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IntId");

                    b.ToTable("TblUser");
                });

            modelBuilder.Entity("SMS.Models.TblUserRole", b =>
                {
                    b.Property<long>("IntId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IntId"), 1L, 1);

                    b.Property<long>("IntRoleId")
                        .HasColumnType("bigint");

                    b.Property<long>("IntUserId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("IntId");

                    b.ToTable("TblUserRole");
                });
#pragma warning restore 612, 618
        }
    }
}
