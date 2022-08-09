﻿using System.ComponentModel.DataAnnotations;

namespace MP_MMS.Domain.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }

        public ICollection<Issue> Issues { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
