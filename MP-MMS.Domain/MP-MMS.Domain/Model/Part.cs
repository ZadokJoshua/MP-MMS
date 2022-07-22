namespace MP_MMS.Domain.Model
{
    public class Part : DomainObject
    {
        public string? Name { get; set; }
        public int? SerialNumber { get; set; }
        public string? Manufacturer { get; set; }
        public string? ImageLocation { get; set; }
        public double UnitCost { get; set; }
        public int TotalUnits { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
