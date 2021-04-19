using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class Course: BaseModel
    {
        [Required(ErrorMessage = "Course name is required")]
        [MaxLength(255 ,ErrorMessage = "Course name max length is 255")]
        public string? Name { get; set; }
        public int? Duration { get; set; }
        public string? Info { get; set; }
        public ICollection<CourseImage> CourseImages { get; set; }
    }
}
