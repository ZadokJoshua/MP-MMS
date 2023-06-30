using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MP_MMS.Domain.Model
{
    public class Part : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Manufacturer { get; set; }

        [Required]
        [MaxLength(100)]
        public string? SerialNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string? ModelNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Category { get; set; }

        [ForeignKey("LocationId")]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        [Index(6)]
        public decimal UnitCost { get; set; }

        public int Quantity { get; set; }

        public DateTime DateAdded { get; set; }


        public ICollection<Issue> Issues { get; set; } = new List<Issue>();

        public override string ToString() => $"{Name}";
    }
}
