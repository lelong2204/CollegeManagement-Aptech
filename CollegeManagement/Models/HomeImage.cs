using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class HomeImage
    {
        public int? ID { get; set; }
        [MaxLength(500)]
        public string? ImgUrl { get; set; }
        [ForeignKey("Home")]
        public int? HomeID { get; set; }
        public byte? Deleted { get; set; }
    }
}
