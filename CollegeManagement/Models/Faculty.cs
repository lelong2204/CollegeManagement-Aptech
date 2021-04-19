using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeManagement.Models
{
    public class Faculty: BaseModel
    {
        [Required(ErrorMessage = "Faculty name is required")]
        [MaxLength(255, ErrorMessage = "Faculty name max length is 255")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Faculty code is required")]
        [MaxLength(10, ErrorMessage = "Faculty code max length is 10")]
        public string? Code { get; set; }
        [MaxLength(1000, ErrorMessage = "Info number max length is 1000")]
        public string? Info { get; set; }
        public string? ImageUrl { get; set; }
        [ForeignKey("Teacher")]
        public int? DeanID { get; set; }
        public Department Department { get; set; }
    }
}
