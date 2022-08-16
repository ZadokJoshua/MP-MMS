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
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Part> Parts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Initial Catalog=MP_MMS_DB; Timeout=4000000");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
