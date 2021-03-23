using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$",
         ErrorMessage = "Password most have one number," +
         "one lowercase, and one uppercase character, and from 4-8 total long.")]
        public string Password { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
