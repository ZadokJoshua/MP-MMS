using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MP_MMS.Domain.Model
{
    public class Part : BaseModel
    {
        [Required]
        [MaxLength(50)]
        [Index(0)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Index(1)]
        public string? Manufacturer { get; set; }

        [Required]
        [MaxLength(100)]
        [Index(2)]
        public string? SerialNumber { get; set; }

        [Required]
        [MaxLength(100)]
        [Index(3)]
        public string? ModelNumber { get; set; }

        [Required]
        [MaxLength(100)]
        [Index(4)]
        public string? Category { get; set; }

        [Index(5)]
        [ForeignKey("LocationId")]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        [Index(6)]
        public decimal UnitCost { get; set; }

        [Index(7)]
        public int Quantity { get; set; }

        [Index(8)]
        public DateTime DateAdded { get; set; }


        public ICollection<Issue> Issues { get; set; } = new List<Issue>();

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
