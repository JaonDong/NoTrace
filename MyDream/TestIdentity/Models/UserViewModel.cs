using System.ComponentModel.DataAnnotations;

namespace TestIdentity.Models
{
    public class UserViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}