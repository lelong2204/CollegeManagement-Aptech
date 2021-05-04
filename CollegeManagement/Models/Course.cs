using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class Course: BaseModel
    {
        [Required(ErrorMessage = "Course name is required")]
        [MaxLength(255 ,ErrorMessage = "Course name max length is 255")]
        public string? Name { get; set; }
        public string? Info { get; set; }
        public ICollection<CourseImage> CourseImages { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Semester number must be greater than or equal 1")]
        public int? SemesterNumber { get; set; }
        [Range(1, 5, ErrorMessage = "Evaluate must be between 1 and 5")]
        public int? Evaluate { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater than or equal 0")]
        public int? Price { get; set; }
        public byte? Focus { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentID { get; set; }
        public ICollection<Class> Classes { get; set; }
        public ICollection<CourseSubject> CourseSubjects { get; set; }
    }
}
