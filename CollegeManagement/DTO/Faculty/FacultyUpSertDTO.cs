using CollegeManagement.DTO.Departments;
using CollegeManagement.DTO.Subject;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CollegeManagement.DTO.Faculty
{
    public class FacultyUpSertDTO
    {
        public int? ID { get; set; }
        [Required(ErrorMessage = "Faculty name is required")]
        [MaxLength(255, ErrorMessage = "Faculty name max length is 255")]
        public string? Name { get; set; }
        [MaxLength(1000, ErrorMessage = "Faculty info max length is 1000")]
        public string? Info { get; set; }
        public byte? Gender { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile Image { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        [MaxLength(500, ErrorMessage = "Address max length is 255")]
        public string? Address { get; set; }
        [MaxLength(500)]
        [EmailAddress(ErrorMessage = "Wrong email address format")]
        public string? Email { get; set; }
        [MaxLength(11)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Wrong phone number format")]
        public string? PhoneNumber { get; set; }
        [Range(0, 100, ErrorMessage = "Experience year must be between 0 and 100")]
        public int? ExperienceYear { get; set; }
        [Required(ErrorMessage = "Department is required")]
        public int? DepartmentID { get; set; }
        public List<int> SubjectIDs { get; set; }
        public IQueryable<DepartmentSelectDTO> DepartmentList { get; set; }
        public IQueryable<SubjectSelectDTO> SubjectList { get; set; }
    }
}
