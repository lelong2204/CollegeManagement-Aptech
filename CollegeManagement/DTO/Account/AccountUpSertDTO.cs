using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.DTO.Account
{
    public class AccountUpSertDTO
    {
        public List<string> UserRole = new List<string>() { "Admin", "Faculty", "Student" };
        [Required(ErrorMessage = "Full name is required")]
        public string? FullName { get; set; }
        [MaxLength(500)]
        [EmailAddress(ErrorMessage = "Wrong email address format")]
        public string? Email { get; set; }
        [MaxLength(11)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Wrong phone number format")]
        public string? PhoneNumber { get; set; }
        [MaxLength(500)]
        public string? ImageURL { get; set; }
        public IFormFile Image { get; set; }
        public string? Address { get; set; }
        [Required(ErrorMessage = "User name is required")]
        [MaxLength(64, ErrorMessage = "The maximum length of the user name is 64")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MaxLength(255, ErrorMessage = "The maximum length of the password is 255")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }
        public int? TargetID { get; set; }
    }
}
