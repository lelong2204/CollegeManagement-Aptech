using CollegeManagement.DTO.Departments;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CollegeManagement.DTO.Student
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
        [Required(ErrorMessage = "Student name is required")]
        [MaxLength(255, ErrorMessage = "The maximum length of the name is 255")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Responsible person name is required")]
        [MaxLength(255, ErrorMessage = "The maximum length of the responsible person name is 255")]
        [Display(Name = "Responsible person name")]
        public string? ResponsiblePersonName { get; set; }

        [Required(ErrorMessage = "Responsible person phone is required")]
        [MaxLength(11, ErrorMessage = "The maximum length of the responsible person phone is 255")]
        [Display(Name = "Responsible person phone")]
        public string? ResponsiblePersonPhone { get; set; }
        [Required(ErrorMessage = "Student code is required")]
        [MaxLength(20, ErrorMessage = "The maximum length of the code is 20")]
        public string? Code { get; set; }
        [MaxLength(500)]
        [EmailAddress(ErrorMessage = "Wrong email format")]
        public string? Email { get; set; }
        [MaxLength(11)]
        [Display(Name = "Phone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Wrong phone number format")]
        public string? PhoneNumber { get; set; }
        [MaxLength(500, ErrorMessage = "The maximum length of the residential address is 500")]
        [Display(Name = "Residential address")]
        public string? ResidentialAddress { get; set; }
        [MaxLength(500, ErrorMessage = "The maximum length of the permanent address is 500")]
        [Display(Name = "Permanent address")]
        public string? PermanentAddress { get; set; }
        [MaxLength(500, ErrorMessage = "The maximum length of the image url is 500")]
        public string? ImageURL { get; set; }
        public IFormFile Image { get; set; }
        public byte? Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        public int? Status { get; set; }
        [Required(ErrorMessage = "The course is required")]
        public int? CourseID { get; set; }
        public int? Admission { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "The test score must be larger than 0")]
        [Required()]
        [Display(Name = "Test Score")]
        public int? TestScore { get; set; }
        public IQueryable<DepartmentSelectDTO> CourseList { get; set; }
    }
}
