using System.ComponentModel.DataAnnotations;

namespace MP_MMS.Domain.Model
{
    public class Employee : BaseModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }

        public ICollection<Issue> Issues { get; set; } = new List<Issue>();

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
