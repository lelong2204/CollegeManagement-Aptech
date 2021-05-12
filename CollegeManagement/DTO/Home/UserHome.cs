using CollegeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.DTO.Home
{
    public class UserHome
    {
        public List<Content> Histories { get; set; }
        public List<Content> Event { get; set; }
        public List<Models.Course> Courses { get; set; }
        public List<Models.Faculty> Faculties { get; set; }
        public int TotalStudent { get; set; }
        public int TotalCourse { get; set; }
        public int Year { get; set; }
    }
}
