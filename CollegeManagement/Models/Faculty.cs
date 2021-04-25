using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeManagement.Models
{
    public class Faculty: BaseModel
    {
        [Required(ErrorMessage = "Faculty name is required")]
        [MaxLength(255, ErrorMessage = "Faculty name max length is 255")]
        public string? Name { get; set; }
        [MaxLength(1000, ErrorMessage = "Faculty info max length is 1000")]
        public string? Info { get; set; }
        [Required(ErrorMessage = "Faculty code is required")]
        [MaxLength(10, ErrorMessage = "Faculty code max length is 10")]
        public string? Code { get; set; }
        public byte? Gender { get; set; }
        [MaxLength(500)]
        public string? ImageUrl { get; set; }
        public DateTime? DOB { get; set; }
        [MaxLength(500, ErrorMessage = "Address max length is 255")]
        public string? Address { get; set; }
        [MaxLength(11, ErrorMessage = "Phone number max length is 11")]
        [Phone(ErrorMessage = "Phone number is wrong format")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(255, ErrorMessage = "Email max length is 255")]
        [EmailAddress(ErrorMessage = "Email is wrong format")]
        public string? Email { get; set; }
        public int? ExperienceYear { get; set; }
        public Department Department { get; set; }
        public ICollection<FacultySubject> FacultySubject { get; set; }
    }
}
