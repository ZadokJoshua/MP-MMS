using System.ComponentModel.DataAnnotations;

namespace MP_MMS.Domain.Model
{
    public class User : BaseModel
    {
        [Required]
        [MaxLength(10)]
        public string? UserName { get; set; }

        [Required]
        [MaxLength(15)]
        public string? Password { get; set; }
    }
}
