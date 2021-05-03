using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class User : BaseModel
    {
        public string? FullName { get; set; }
        [MaxLength(500)]
        public string? Email { get; set; }
        [MaxLength(11)]
        public string? PhoneNumber { get; set; }
        [MaxLength(500)]
        public string? ImageURL { get; set; }
        public string? Address { get; set; }
        [Required(ErrorMessage = "User name is required")]
        [MaxLength(64, ErrorMessage = "The maximum length of the user name is 64")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MaxLength(255, ErrorMessage = "The maximum length of the password is 255")]
        public string Password { get; set; }
    }
}
