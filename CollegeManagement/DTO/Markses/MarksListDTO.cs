using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.DTO.Markses
{
    public class MarksListDTO
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
    }
}
