using System.ComponentModel.DataAnnotations;

namespace MP_MMS.Domain.Model
{
    public class Employee : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string? LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Role { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public ICollection<Issue> Issues { get; set; } = new List<Issue>();

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
