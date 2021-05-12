using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeManagement.Models
{
    public class Marks: BaseModel
    {
        public enum MarksStatus
        {
            Failed,
            Pass
        }

        [ForeignKey("Subject")]
        public int? SubjectID { get; set; }
        [ForeignKey("Student")]
        public int? StudentID { get; set; }
        [Range(0, 20, ErrorMessage = "Score must be between 0 and 20")]
        public int? Score { get; set; }
        public int? Status { get; set; }
    }
}
