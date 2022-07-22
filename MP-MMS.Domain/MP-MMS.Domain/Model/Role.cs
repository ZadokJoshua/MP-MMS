namespace MP_MMS.Domain.Model
{
    public class Role : DomainObject
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Workshop? Workshop { get; set; }
    }
}
