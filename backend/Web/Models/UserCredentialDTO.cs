using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class UserCredentialDTO
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
