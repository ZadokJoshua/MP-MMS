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
        public MPMMSDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
