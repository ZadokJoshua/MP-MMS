using Microsoft.EntityFrameworkCore;
using MP_MMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MMS.Data
{
    public class MPMMSDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Issue> Issues { get; set; } = null!;
        public DbSet<Location> Locations { get; set; } = null!;
        public DbSet<Part> Parts { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Initial Catalog=MP_MMS_DB; Timeout=4000");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "Admin",
                Password = "Admin"
            });

            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Id = 1,
                    Name = "Mechanical Engineering Workshop 1",
                    Address = "SIPET, Mechanical Engineering Building, Gidan-Kwanu Campus, Minna"
                },
                new Location
                {
                    Id = 2,
                    Name = "Mechanical Engineering Workshop 2",
                    Address = "Opposite Engineering Complex, Gidan-Kwanu Campus, Minna"
                },
                new Location
                {
                    Id = 3,
                    Name = "CNC Workshop 1",
                    Address = "Opposite Engineering Complex, Gidan-Kwanu Campus, Minna"
                },
                new Location
                {
                    Id = 4,
                    Name = "Milling Workshop 1",
                    Address = "Physics Department, Bosso Campus, Minna"
                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee 
                { 
                    Id = 1,
                    FirstName = "Mike",
                    LastName = "Jonathan",
                    Email = "mikejonathan@mpmms.com",
                    Role = "Electrician"
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Susan",
                    LastName = "Aaron",
                    Email = "susanaaron@mpmms.com",
                    Role = "Safety officer"
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Barnabas",
                    LastName = "Otee",
                    Email = "barnabasotee@mpmms.com",
                    Role = "CNC Operator"
                });

            modelBuilder.Entity<Part>().HasData(
                new Part
                {
                    Id = 1,
                    Name = "Face-Mount AC Motors",
                    Manufacturer = "McMaster Engineering Limited",
                    Category = "Actuator",
                    DateAdded= DateTime.Now,
                    LocationId = 1,
                    ModelNumber = "C5-1",
                    SerialNumber = "732675",
                    UnitCost = 1200,
                    Quantity = 3,
                },
                 new Part
                 {
                     Id = 2,
                     Name = "Auto-Darkening Welding Helmets",
                     Manufacturer = "Fiberglass Engineering",
                     Category = "Others",
                     DateAdded = DateTime.Now,
                     LocationId = 3,
                     ModelNumber = "ADW-4F",
                     SerialNumber = "N/A",
                     UnitCost = 3200,
                     Quantity = 2,
                 },
                  new Part
                  {
                      Id = 3,
                      Name = "Wraparound Welding Glasses",
                      Manufacturer = "Fiberglass Engineering",
                      Category = "Others",
                      DateAdded = DateTime.Now,
                      LocationId = 3,
                      ModelNumber = "WWG-2F",
                      SerialNumber = "N/A",
                      UnitCost = 200,
                      Quantity = 30,
                  },
                   new Part
                   {
                       Id = 4,
                       Name = "Sprockets for Conveyor Chain Belts",
                       Manufacturer = "McMaster Engineering Limited",
                       Category = "Belt",
                       DateAdded = DateTime.Now,
                       LocationId = 2,
                       ModelNumber = "SPCON-A2",
                       SerialNumber = "263712",
                       UnitCost = 1200,
                       Quantity = 12,
                   },
                    new Part
                    {
                        Id = 5,
                        Name = "Compressed Air Storage Tank",
                        Manufacturer = "BlueLight",
                        Category = "Others",
                        DateAdded = DateTime.Now,
                        LocationId = 1,
                        ModelNumber = "T3-CAS",
                        SerialNumber = "9888K9",
                        UnitCost = 5500,
                        Quantity = 1,
                    },
                     new Part
                     {
                         Id = 6,
                         Name = "Bearings for suspension system",
                         Manufacturer = "McMaster Engineering Limited",
                         Category = "Bearing",
                         DateAdded = DateTime.Now,
                         LocationId = 2,
                         ModelNumber = "N/A",
                         SerialNumber = "4712",
                         UnitCost = 50,
                         Quantity = 2,
                     });

            modelBuilder.Entity<Issue>().HasData(
                new Issue
                {
                    Id = 1,
                    Name = "Damage Bearings",
                    Description = "Replace damage bearings.",
                    EmployeeId = 1,
                    DueDate= DateTime.Now.AddDays(1),
                    IsCompleted = false,
                    PartId = 6,
                    Priority = "Medium",
                },
                new Issue
                {
                    Id = 2,
                    Name = "Broken welding helmet screen",
                    Description = "Replace broken welding helmet screen with the newer screen that are available in store 1.",
                    EmployeeId = 2,
                    DueDate = DateTime.Now.AddDays(5),
                    IsCompleted = true,
                    PartId = 2,
                    Priority = "Low",
                },
                new Issue
                {
                    Id = 3,
                    Name = "Tank leakage",
                    Description = "There's is a leakage at the bottom of the Compressed Air Storage Tank. Please work together with the welder to fix the issue.",
                    EmployeeId = 2,
                    DueDate = DateTime.Now.AddDays(1),
                    IsCompleted = false,
                    PartId = 5,
                    Priority = "Medium",
                });
        }
    }
}
