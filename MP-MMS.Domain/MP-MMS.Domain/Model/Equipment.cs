namespace MP_MMS.Domain.Model
{
    public class Equipment : BaseModel
    {
        public string? Name { get; set; }
        public string? Manufacturer { get; set; }
        public int? ModelNumber { get; set; }
        public int? SerialNumber { get; set; }
        public string? ImageLocation { get; set; }
        public decimal UnitCost { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
