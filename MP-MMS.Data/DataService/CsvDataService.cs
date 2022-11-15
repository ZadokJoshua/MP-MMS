using CsvHelper;
using MP_MMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MMS.Data.DataService
{
    public static class CsvDataService<T>
    {
        static public async void BulkInsertOperation(string filePath)
        {
            //IEnumerable<Part> records = new List<Part>();
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Part>();
                if (records != null)
                {
                    using (MPMMSDbContext context = new())
                    {
                        await context.Parts.AddRangeAsync(records);
                        await context.SaveChangesAsync();
                    }
                }
            }

            //if (records != null)
            //{
            //    using(MPMMSDbContext context = new())
            //    {
            //        await context.Parts.AddRangeAsync(records);
            //        await context.SaveChangesAsync();
            //    }
            //}
        }
    }
}
