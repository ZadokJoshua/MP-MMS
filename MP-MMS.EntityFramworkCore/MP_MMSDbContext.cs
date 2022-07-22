using Microsoft.EntityFrameworkCore;
using MP_MMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MMS.EntityFramworkCore
{
    public class MP_MMSDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<MaintenanceWO> MaintenanceWOs { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public MP_MMSDbContext(DbContextOptions options) : base(options) { }

    }
}
