﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SMS.DBContext;

#nullable disable

namespace SMS.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240203114535_new")]
    partial class @new
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SMS.Models.TblApplicantAcademicInfo", b =>
                {
                    b.Property<long>("IntId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IntId"), 1L, 1);

                    b.Property<long>("IntApplicantHeaderId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("NumResult")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("PassingYear")
                        .HasColumnType("bigint");

                    b.Property<long>("Scale")
                        .HasColumnType("bigint");

                    b.Property<string>("StrInstitutionName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("IntId");

                    b.ToTable("TblApplicantAcademicInfo");
                });

            modelBuilder.Entity("SMS.Models.TblApplicantInfoHeader", b =>
                {
                    b.Property<long>("IntId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IntId"), 1L, 1);

                    b.Property<DateTime?>("DteActionDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DteDoB")
                        .HasColumnType("datetime2");

                    b.Property<long>("IntFirstDepartmentId")
                        .HasColumnType("bigint");

                    b.Property<long>("IntOptionalDepartmentId")
                        .HasColumnType("bigint");

                    b.Property<long>("IntSemesterId")
                        .HasColumnType("bigint");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsClose")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsForPostGraduate")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPassed")
                        .HasColumnType("bit");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("NumTotakMark")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("StrAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrAttachment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrFatherContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrFatherEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrFatherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrFirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("StrFullName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("StrGender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrLastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("StrRegistrationCode")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("IntId");

                    b.ToTable("TblApplicantInfoHeader");
                });

            modelBuilder.Entity("SMS.Models.TblDepartment", b =>
                {
                    b.Property<long>("IntId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IntId"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("StrDepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IntId");

                    b.ToTable("TblDepartment");
                });

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

            modelBuilder.Entity("SMS.Models.TblSemester", b =>
                {
                    b.Property<long>("IntId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IntId"), 1L, 1);

                    b.Property<DateTime?>("DteApplicationDeadLine")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DteLastActionDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("StrSemesterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IntId");

                    b.ToTable("TblSemester");
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
