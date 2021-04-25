using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class Student : BaseModel
    {
        [Required(ErrorMessage = "Student name is required")]
        [MaxLength(255, ErrorMessage = "The maximum length of the name is 255")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Student code is required")]
        [MaxLength(255, ErrorMessage = "The maximum length of the code is 255")]
        public string? Code { get; set; }
        [MaxLength(500, ErrorMessage = "The maximum length of the mail is 500")]
        [EmailAddress(ErrorMessage = "Email is wrong format")]
        public string? Email { get; set; }
        [MaxLength(11, ErrorMessage = "The maximum length of the phone is 11")]
        [Phone(ErrorMessage = "Email is wrong format")]
        public string? Phone { get; set; }
        [MaxLength(500, ErrorMessage = "The maximum length of the address is 500")]
        public string? Address { get; set; }
        public byte? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public int? Status { get; set; }
        public ICollection<Marks> Marks { get; set; }
        public ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
