using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class Facilities : BaseModel
    {
        [Required(ErrorMessage = "Facilities name is required")]
        [MaxLength(255, ErrorMessage = "Facilities name max length is 255")]
        public string? Name { get; set; }
        public int? Qty { get; set; }
        [MaxLength(1000, ErrorMessage = "Facilities info max length is 1000")]
        public string? Info { get; set; }
    }
}
