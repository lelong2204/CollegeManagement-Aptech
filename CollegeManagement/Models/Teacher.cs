using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class Teacher: BaseModel
    {
        [Required(ErrorMessage = "Teacher name is required")]
        [MaxLength(255, ErrorMessage = "Teacher name max length is 255")]
        public string? Name { get; set; }
        [MaxLength(1000, ErrorMessage = "Info number max length is 1000")]
        public string? Info { get; set; }
        [Required(ErrorMessage = "Teacher code is required")]
        [MaxLength(10, ErrorMessage = "Teacher code max length is 10")]
        public string? Code { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? DOB { get; set; }
        public string? Address { get; set; }
        [MaxLength(11, ErrorMessage = "Phone number max length is 11")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(255, ErrorMessage = "Email max length is 255")]
        public string? Email { get; set; }
    }
}
