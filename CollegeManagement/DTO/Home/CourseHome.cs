using CollegeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.DTO.Home
{
    public class CourseHome
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Info { get; set; }
        public int? DepartmentID { get; set; }
        public int? StudentNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int StudentRegister { get; set; }
        public string? ImageURL { get; set; }
        public int TotalBook { get; set; }
        public int? Status { get; set; }
    }
}
