using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeManagement.Models
{
    public class Department: BaseModel
    {
        [Required(ErrorMessage = "Department name is required")]
        [MaxLength(255, ErrorMessage = "Department name max length is 255")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Department infomation is required")]
        [MaxLength(2000, ErrorMessage = "Department infomation max length is 255")]
        public string? Info { get; set; }
        public ICollection<Faculty> Faculties { get; set; }
    }
}
