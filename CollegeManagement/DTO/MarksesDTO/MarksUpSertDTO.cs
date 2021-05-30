using CollegeManagement.DTO.SubjectDTO;
using System.Collections.Generic;

namespace CollegeManagement.DTO.MarksesDTO
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
