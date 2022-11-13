using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MP_MMS.Domain.Model
{
    public class Issue : BaseModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        
        [ForeignKey("PartId")]
        public int PartId { get; set; }
        public Part Part { get; set; }

        
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public string? Priority { get; set; }
        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
