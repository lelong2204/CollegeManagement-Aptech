using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class FacilityImg
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string? ImgUrl { get; set; }
        [Required]
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
    }
}
