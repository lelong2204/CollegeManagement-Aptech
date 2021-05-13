using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Departments.DTO
{
    public class DepartmentUpSertDTO
    {
        public int? ID { get; set; }
        [Required()]
        [MaxLength(255)]
        public string? Name { get; set; }
        [Required()]
        [MaxLength(2000)]
        public string? Info { get; set; }
    }
}
