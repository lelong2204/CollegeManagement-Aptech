using CollegeManagement.DTO.Departments;
using CollegeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.DTO.Home
{
    public class CourseDetailsDTO
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Info { get; set; }
        public string ImageURL { get; set; }
        public int? StudentNumber { get; set; }
        public int? StudentRegisterNumber { get; set; }
        public string Subjects { get; set; }
        public int? Price { get; set; }
        public int? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public IEnumerable<CourseSubject> SubjectList { get; set; }
        public int? DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}
