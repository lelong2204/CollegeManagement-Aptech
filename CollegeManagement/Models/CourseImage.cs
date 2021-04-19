using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class CourseImage
    {
        public int? ID { get; set; }
        public string? ImgUrl { get; set; }
        [ForeignKey("Course")]
        public int? CourseID { get; set; }
        public byte? Deleted { get; set; }
    }
}
