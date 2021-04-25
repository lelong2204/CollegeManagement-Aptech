using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class StudentCourse
    {
        public int ID { get; set; }
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public Student Student { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}
