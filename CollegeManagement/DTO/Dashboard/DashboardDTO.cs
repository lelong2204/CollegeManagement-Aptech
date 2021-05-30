using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.DTO.Dashboard
{
    public class DashboardDTO
    {
        public int? TotalStudent { get; set; }
        public int? TotalStudentAdmission { get; set; }
        public int? TotalFaculty { get; set; }
        public int? TotalCourse { get; set; }
        public int? TotalCourseAvaiable { get; set; }
        public int? TotalPost { get; set; }
        public List<StudentPerYear> StudentPerYear { get; set; }
        public List<CourseStudentNumber> CourseStudentNumber { get; set; }
    }

    public class CourseStudentNumber
    {
        public string CourseName { get; set; }
        public int TotalStudentRegister { get; set; }
    }

    public class StudentPerYear
    {
        public int Year { get; set; }
        public int TotalStudent { get; set; }
        public int TotalStudentAdmission { get; set; }
        public int TotalStudentFailed { get; set; }
        public int TotalStudentGraduating { get; set; }
        public int TotalStudentExpelled { get; set; }
    }
}
