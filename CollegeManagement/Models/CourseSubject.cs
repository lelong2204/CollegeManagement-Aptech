using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeManagement.Models
{
    public class CourseSubject
    {
        public int ID { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public Course Course { get; set; }
        [ForeignKey("Subject")]
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }
        [ForeignKey("Faculty")]
        public int FacultyID { get; set; }
        public Faculty Faculty { get; set; }

    }
}
