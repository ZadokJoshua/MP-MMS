using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MP_MMS.Domain.Model
{
    public class Location : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string? Address { get; set; }

        public ICollection<Part> Parts { get; set; } = new List<Part>();

        public override string ToString() => $"{Name}";
    }
}
