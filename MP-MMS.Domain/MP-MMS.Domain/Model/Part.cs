using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MP_MMS.Domain.Model
{
    public class Part
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Manufacturer { get; set; }
        public int? SerialNumber { get; set; }
        public int? ModelNumber { get; set; }
        public string? Category { get; set; }

        public string LocationName { get; set; }
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        public decimal UnitCost { get; set; }
        public int Quantity { get; set; }
        public DateOnly DateAdded { get; set; }


        public ICollection<Issue> Issues { get; set; }
    }
}
