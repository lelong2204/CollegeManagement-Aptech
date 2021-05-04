using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class Class : BaseModel
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Class name max length is 50")]
        public string? Name { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Max student number per course must be greater than or equal 0")]
        public int? MaxStudentPerClass { get; set; }
        [ForeignKey("Course")]
        public int? CourseID { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
