using System.ComponentModel.DataAnnotations;

namespace MP_MMS.Domain.Model
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        public ICollection<Part> Parts { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
