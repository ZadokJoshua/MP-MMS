using CsvHelper;
using CsvHelper.Configuration;
using MP_MMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MMS.Data.DataService;

public static class CsvDataService
{
    public static IEnumerable<Part> Parts { get; private set; }

    private static string csvPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"mpmms-parts-{DateTime.Now.ToFileTime()}.csv");

    public static void ExportRecords(IEnumerable<Part> parts)
    {
        Parts = parts;
        using (StreamWriter writer = new StreamWriter(csvPath))
        {
            using (CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.Context.RegisterClassMap<PartClassMap>();
                csvWriter.WriteRecords(parts);
            }
        }
    }
}

public class PartClassMap : ClassMap<Part>
{
    public PartClassMap()
    {
        Map(p => p.Name).Index(0).Name("part_name");
        Map(p => p.Manufacturer).Index(1).Name("manufacturer");
        Map(p => p.SerialNumber).Index(2).Name("serial_number");
        Map(p => p.ModelNumber).Index(3).Name("model_number");
        Map(p => p.Category).Index(4).Name("category");
        Map(p => p.Location).Index(5).Name("location");
        Map(p => p.UnitCost).Index(6).Name("unit_cost");
        Map(p => p.Quantity).Index(7).Name("quantity");
        Map(p => p.DateAdded).Index(8).Name("date_added").TypeConverterOption.Format("s");
    }
}
