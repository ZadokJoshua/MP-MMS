﻿namespace MP_MMS.Domain.Model
{
    public class User : DomainObject
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}