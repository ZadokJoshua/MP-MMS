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
        public string? SerialNumber { get; set; }
        public string? ModelNumber { get; set; }
        public string? Category { get; set; }

        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        public double UnitCost { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }


        public ICollection<Issue> Issues { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
