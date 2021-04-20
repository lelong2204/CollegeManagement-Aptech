using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class SubjectCourse
    {
        public int ID { get; set; }
        [ForeignKey("Subject")]
        public int SubjectID { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }
    }
}
