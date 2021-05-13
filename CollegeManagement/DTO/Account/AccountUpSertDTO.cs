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
        public string? FullName { get; set; }
        [MaxLength(500)]
        [EmailAddress()]
        public string? Email { get; set; }
        [MaxLength(11)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Wrong phone number format")]
        public string? PhoneNumber { get; set; }
        [MaxLength(500)]
        public string? ImageURL { get; set; }
        public IFormFile Image { get; set; }
        public string? Address { get; set; }
        [Required()]
        [MaxLength(64)]
        public string UserName { get; set; }
        [Required()]
        [MaxLength(255)]
        public string Password { get; set; }
        [Required()]
        public string Role { get; set; }
        public int? TargetID { get; set; }
    }
}
