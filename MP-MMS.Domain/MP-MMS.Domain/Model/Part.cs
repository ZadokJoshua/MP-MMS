using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MP_MMS.Domain.Model
{
    public class Part : BaseModel
    {
        public string? Name { get; set; }
        public string? Manufacturer { get; set; }
        public string? SerialNumber { get; set; }
        public string? ModelNumber { get; set; }
        public string? Category { get; set; }

        
        [ForeignKey("LocationId")]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public double UnitCost { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }


        public ICollection<Issue> Issues { get; set; } = new List<Issue>();

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
