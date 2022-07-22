namespace MP_MMS.Domain.Model
{
    public class Maintenance : DomainObject
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Priority { get; set; }
        public Role AssignedTo { get; set; }
        public Part Part { get; set; }
    }
}
