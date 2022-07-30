namespace MP_MMS.Domain.Model
{
    public class MaintenanceWO : BaseModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Employee? AssignedTo { get; set; }
        public DateTime DueDate { get; set; }
        public string? WOImageLocation { get; set; }
        public Equipment? Equipment { get; set; }
        public bool IsCompleted { get; set; }
    }
}
