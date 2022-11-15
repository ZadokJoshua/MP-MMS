using System.ComponentModel.DataAnnotations;

namespace MP_MMS.Domain.Model
{
    public class Location : BaseModel
    {
        public string? Name { get; set; }
        public string? Address { get; set; }

        public ICollection<Part> Parts { get; set; } = new List<Part>();

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
