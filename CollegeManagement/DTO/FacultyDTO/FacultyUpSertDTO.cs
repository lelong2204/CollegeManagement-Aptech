using CollegeManagement.DTO.DepartmentsDTO;
using CollegeManagement.DTO.SubjectDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CollegeManagement.DTO.FacultyDTO
{
    public class FacultyUpSertDTO
    {
        public int? ID { get; set; }
        [Required()]
        [MaxLength(255)]
        public string? Name { get; set; }
        [MaxLength(1000)]
        public string? Info { get; set; }
        [MaxLength(500)]
        public string? Testimonials { get; set; }
        [Required()]
        public byte? Gender { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile Image { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        [MaxLength(500)]
        [Required()]
        public string? Address { get; set; }
        [MaxLength(500)]
        [EmailAddress()]
        [Required()]
        public string? Email { get; set; }
        [Required()]
        [MaxLength(11)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Wrong phone number format")]
        public string? PhoneNumber { get; set; }
        [Range(0, 100)]
        [Required()]
        public int? ExperienceYear { get; set; }
        [Required()]
        public int? DepartmentID { get; set; }
        public List<int> SubjectIDs { get; set; }
        public IQueryable<DepartmentSelectDTO> DepartmentList { get; set; }
        public IQueryable<SubjectSelectDTO> SubjectList { get; set; }
    }
}
