using HWC_Code_First_Approach.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HWC_Code_First_Approach.DbContextt
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<EmployeeProfile> EmployeeProfiles => Set<EmployeeProfile>();
        public DbSet<Project> Projects => Set<Project>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=VIVOBOOK16\MSSQLSERVER_2022;Database=HW_Code_First;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=""SQL Server Management Studio"";Command Timeout=0");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Company -> Employees
            //1 : N
            modelBuilder.Entity<Company>()
                .HasMany(e => e.Employees)
                .WithOne(c => c.Company)
                .HasForeignKey(e => e.CompanyId);
            //Employee -> Projects
            //N : N
            modelBuilder.Entity<Employee>()
                .HasMany(p => p.Projects)
                .WithMany(e => e.Employees)
                .UsingEntity(j => j.ToTable("EmployeeProjects"));
            //Employee -> EmployeeProfile
            //1 : 1
            modelBuilder.Entity<Employee>()
                .HasOne(p => p.Profile)
                .WithOne(e => e.Employee)
                .HasForeignKey<EmployeeProfile>(e => e.EmployeeId);
        }

    }
}
