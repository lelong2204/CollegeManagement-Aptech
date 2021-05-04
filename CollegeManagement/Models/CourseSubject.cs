using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeManagement.Models
{
    public class CourseSubject
    {
        public enum SubjectLevel
        {
            Advanced,
            Basic
        };

        public int ID { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public Course Course { get; set; }
        [ForeignKey("Subject")]
        public int SubjectID { get; set; }
        public int Level { get; set; }
        public Subject Subject { get; set; }

    }
}
