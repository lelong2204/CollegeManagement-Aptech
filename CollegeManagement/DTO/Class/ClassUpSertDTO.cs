using CollegeManagement.DTO.Course;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.DTO.Class
{
    public class ClassUpSertDTO
    {
        public int? ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Class name max length is 50")]
        public string Name { get; set; }
        [Range(1, 100, ErrorMessage = "Max student number per course must be between 1 and 100")]
        public int? MaxStudentPerClass { get; set; }
        public int? CourseID { get; set; }
        public IQueryable<CourseSelectDTO> CourseList { get; set; }
    }
}
