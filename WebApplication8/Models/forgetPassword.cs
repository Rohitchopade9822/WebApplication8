using System.ComponentModel.DataAnnotations;

namespace WebApplication8.Models
{
    public class forgetPassword
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
