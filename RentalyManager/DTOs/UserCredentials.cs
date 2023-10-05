using System.ComponentModel.DataAnnotations;

namespace RentalyManager.DTOs
{
    public class UserCredentials
    {
        [Required]
        [EmailAddress, MaxLength(120)]
        public string email { get; set; }
        [Required]
        [MinLength(8)]
        public string password { get; set; }
    }
}
