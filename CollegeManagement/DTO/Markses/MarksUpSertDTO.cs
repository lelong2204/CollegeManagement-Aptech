using CollegeManagement.DTO.Subject;
using CollegeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.DTO.Markses
{
    public class MarksUpSertDTO
    {
        public List<MarksSelectDTO> Marks { get; set; }
        public string MarkJson { get; set; }
        public SubjectSelectDTO Subject { get; set; }
        public int? SubjectID { get; set; }
        public int? CourseID { get; set; }
    }
}
