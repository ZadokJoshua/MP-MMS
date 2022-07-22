namespace MP_MMS.Domain.Model
{
    public class Employee : DomainObject
    {
        public string? Name { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }
        public Workshop? Workshop { get; set; }
    }
}
