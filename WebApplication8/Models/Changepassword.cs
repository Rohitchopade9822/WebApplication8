using System.ComponentModel.DataAnnotations;

namespace WebApplication8.Models
{
    public class Changepassword
    {
        [Required]
        public string Username { get; set; }
            

        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }


        [Required]
        [Compare("NewPassword")]
        public string Confirmpassword { get; set; }



    }
}
