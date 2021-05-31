using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class Facility : BaseModel
    {
        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }
        public int? Qty { get; set; }
        [MaxLength(1000)]
        public string? Info { get; set; }
        public ICollection<FacilityImg> FacilityImgs { get; set; }
    }
}
