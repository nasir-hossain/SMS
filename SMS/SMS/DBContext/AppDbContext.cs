using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SMS.Models;
using System.Collections.Generic;

namespace SMS.DBContext
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TblUser> TblUser { get; set; } 
        public DbSet<TblRole> TblRole { get; set; }
        public DbSet<TblUserRole> TblUserRole { get; set; } 
        public DbSet<TblDepartment> TblDepartment { get; set; } 
        public DbSet<TblSemester> TblSemester { get; set; } 
        public DbSet<TblApplicantAcademicInfo> TblApplicantAcademicInfo { get; set; } 
        public DbSet<TblApplicantInfoHeader> TblApplicantInfoHeader { get; set; } 
        public DbSet<TblCodeGenerator> TblCodeGenerator { get; set; } 
        public DbSet<TblCourse> TblCourse { get; set; } 

    }
}
