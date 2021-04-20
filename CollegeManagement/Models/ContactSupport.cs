using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class ContactSupport: BaseModel
    {
        [MaxLength(255, ErrorMessage = "First name max length is 255")]
        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get;set; }
        [MaxLength(255, ErrorMessage = "Last name max length is 255")]
        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; set; }
        [MaxLength(500, ErrorMessage = "Email max length is 500")]
        [EmailAddress(ErrorMessage = "Email is wrong format")]
        public string? Email { get; set; }
        [MaxLength(11, ErrorMessage = "Phone number max length is 11")]
        [Phone(ErrorMessage = "Phone number is wrong format")]
        public string? PhoneNumber { get; set; }
        [MaxLength(2000, ErrorMessage = "Infomation max length is 2000")]
        public string? Infomation { get; set; }
    }
}
