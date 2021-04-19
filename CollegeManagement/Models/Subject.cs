using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class Subject: BaseModel
    {
        [MaxLength(255, ErrorMessage = "Subject name max length is 255")]
        [Required(ErrorMessage = "Subject name is required")]
        public string? Name { get; set; }
        [MaxLength(2000, ErrorMessage = "Subject name max length is 255")]
        public string? Info { get; set; }
        [MaxLength(500)]
        public string? ImageUrl { get; set; }
    }
}
