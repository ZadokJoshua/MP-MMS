using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MP_MMS.Domain.Model
{
    public class Issue
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public int PartId { get; set; }
        [ForeignKey("PartId")]
        public virtual Part? Part { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }

        public string? Priority { get; set; }
        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }


    }
}
