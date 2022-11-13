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
        }
    }
}
