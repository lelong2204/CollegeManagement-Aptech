using CollegeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.DTO.Home
{
    public class ElectList
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Info { get; set; }
        public string ImageURL { get; set; }
        public List<Student> Students { get; set; }
    }
}
