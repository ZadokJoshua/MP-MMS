using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MMS.EntityFramworkCore
{
    public class MP_MMSDbContextFactory : IDesignTimeDbContextFactory<MP_MMSDbContext>
    {
        public MP_MMSDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<MP_MMSDbContext>();
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MP_MMS_DB;Trusted_Connection=True");

            return new MP_MMSDbContext(options.Options);
        }
    }
}
