using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class Student : BaseModel
    {
        public enum StudentStatus
        {
            Processing,
            Admission,
            Expelled,
            Fail,
            Graduating
        };

        [Required(ErrorMessage = "Student name is required")]
        [MaxLength(255, ErrorMessage = "The maximum length of the name is 255")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Responsible person name is required")]
        [MaxLength(255, ErrorMessage = "The maximum length of the responsible person name is 255")]
        public string? ResponsiblePersonName { get; set; }

        [Required(ErrorMessage = "Responsible person phone is required")]
        [MaxLength(11, ErrorMessage = "The maximum length of the responsible person phone is 255")]
        public string? ResponsiblePersonPhone { get; set; }
        [Required(ErrorMessage = "Student code is required")]
        [MaxLength(20, ErrorMessage = "The maximum length of the code is 20")]
        public string? Code { get; set; }
        [MaxLength(500)]
        public string? Email { get; set; }
        [MaxLength(11)]
        public string? PhoneNumber { get; set; }
        [MaxLength(500, ErrorMessage = "The maximum length of the residential address is 500")]
        public string? ResidentialAddress { get; set; }
        [MaxLength(500, ErrorMessage = "The maximum length of the Permanent address is 500")]
        public string? PermanentAddress { get; set; }
        [MaxLength(500, ErrorMessage = "The maximum length of the image url is 500")]
        public string? ImageURL { get; set; }
        public byte? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public int? Status { get; set; }
        [Required(ErrorMessage = "The course is required")]
        public int? CourseID { get; set; }
        public int? UserID { get; set; }
        public User User { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "The test score must be larger than 0")]
        public int? TestScore { get; set; }
        public ICollection<Marks> Marks { get; set; }
    }
}
