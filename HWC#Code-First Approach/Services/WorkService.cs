using HWC_Code_First_Approach.DbContextt;
using HWC_Code_First_Approach.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HWC_Code_First_Approach.Services
{
    public class WorkService
    {
        public void AddProject(Project p)
        {
            using(var db = new BlogDbContext())
            {
                db.Projects.Add(p);
                db.SaveChanges();
            }
        }
        public void AddEmployee(Employee e)
        {
            using (var db = new BlogDbContext())
            {
                db.Employees.Add(e);
                db.SaveChanges();
            }
        }
        public void AddEmployeeProfile(EmployeeProfile p)
        {
            using (var db = new BlogDbContext())
            {
                db.EmployeeProfiles.Add(p);
                db.SaveChanges();
            }
        }
        public void PrintProjects()
        {
            using (var db = new BlogDbContext())
            {
                Console.WriteLine("Projects");
                var projects = db.Projects.Include(p => p.Employees).ToList();
                foreach(var p in projects)
                {
                    Console.WriteLine(p.Id + " " + p.Title);
                    foreach (var e in p.Employees)
                    {
                        Console.WriteLine("    " + e.Id + " " + e.FullName);
                    }
                }
            }
        }
        public void PrintCompanys()
        {
            using (var db = new BlogDbContext())
            {
                Console.WriteLine("Companys");
                var companys = db.Companies.Include(p => p.Employees).ToList();
                foreach (var p in companys)
                {
                    Console.WriteLine(p.Id + " " + p.Name);
                    foreach (var e in p.Employees)
                    {
                        Console.WriteLine("    " + e.Id + " " + e.FullName);
                    }
                }
            }
        }
        public void PrintEmployeeProfile()
        {
            using (var db = new BlogDbContext())
            {
                Console.WriteLine("Employees");
                var employeesprofile = db.EmployeeProfiles.Include(p => p.Employee).ToList();
                foreach (var p in employeesprofile)
                {
                    Console.WriteLine(p.Id + " " + p.Employee.FullName + " " + p.Address + " " + p.PhoneNumber);
                }
            }
        }
    }
}
