﻿namespace MP_MMS.Domain.Model
{
    public class MaintenanceWO : DomainObject
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Priority { get; set; }
        public Employee? AssignedTo { get; set; }
        public DateTime DueDate { get; set; }
        public string? WOImageLocation { get; set; }
        public Part? Part { get; set; }
        public bool IsCompleted { get; set; }
    }
}