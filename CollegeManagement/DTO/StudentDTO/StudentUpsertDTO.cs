using CollegeManagement.DTO.DepartmentsDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CollegeManagement.DTO.StudentDTO
{
    public class StudentUpsertDTO
    {
        public enum StudentStatus
        {
            Processing,
            Admission,
            Expelled,
            Graduating
        };
        public int? ID { get; set; }
        [Required()]
        [MaxLength(255)]
        public string? Name { get; set; }

        [Required()]
        [MaxLength(255)]
        [Display()]
        public string? ResponsiblePersonName { get; set; }

        [Required()]
        [MaxLength(11)]
        [Display()]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Wrong responsible person phone number format")]

        public string? ResponsiblePersonPhone { get; set; }
        public string? Code { get; set; }
        [Required]
        [MaxLength(500)]
        [EmailAddress()]
        public string? Email { get; set; }
        [MaxLength(11)]
        [Required]
        [Display(Name = "Phone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Wrong phone number format")]
        public string? PhoneNumber { get; set; }
        [MaxLength(500)]
        [Required]
        [Display(Name = "Residential address")]
        public string? ResidentialAddress { get; set; }
        [MaxLength(500)]
        [Required]
        [Display(Name = "Permanent address")]
        public string? PermanentAddress { get; set; }
        [MaxLength(500)]
        public string? ImageURL { get; set; }
        public IFormFile Image { get; set; }
        public byte? Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        public int? Status { get; set; }
        [Required()]
        public int? CourseID { get; set; }
        public int? Admission { get; set; }
        [Range(0, int.MaxValue)]
        [Required()]
        [Display(Name = "Test Score")]
        public float? TestScore { get; set; }
        public List<DepartmentSelectDTO> CourseList { get; set; }
    }
}
