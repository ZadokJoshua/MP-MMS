using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MMS.Data
{
    public class MPMMSDbContextFactory : IDesignTimeDbContextFactory<MPMMSDbContext>
    {
        public MPMMSDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<MPMMSDbContext>();
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Initial Catalog=MP_MMS_DB; Timeout=40000");

            return new MPMMSDbContext(options.Options);
        }
    }
}
