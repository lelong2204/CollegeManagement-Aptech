using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.DTO.Departments
{
    public class DepartmentDataDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int FacultyCount { get; set; }
    }
}
