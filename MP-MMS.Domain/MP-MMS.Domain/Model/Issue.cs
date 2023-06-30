using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MP_MMS.Domain.Model
{
    public class Issue : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string? Description { get; set; }

        [ForeignKey("PartId")]
        public int PartId { get; set; }
        public Part Part { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [MaxLength(10)]
        public string? Priority { get; set; }
        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }

        public override string ToString() => $"{Name}";
    }
}
