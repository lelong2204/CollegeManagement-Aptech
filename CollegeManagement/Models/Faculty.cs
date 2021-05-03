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
        public byte? Gender { get; set; }
        [MaxLength(500)]
        public string? ImageUrl { get; set; }
        public DateTime? DOB { get; set; }
        [MaxLength(500, ErrorMessage = "Address max length is 255")]
        public string? Address { get; set; }
        [MaxLength(500)]
        public string? Email { get; set; }
        [MaxLength(11)]
        public string? PhoneNumber { get; set; }
        public int? ExperienceYear { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentID { get; set; }
        public Department Department { get; set; }
        public ICollection<FacultySubject> FacultySubject { get; set; }
    }
}
