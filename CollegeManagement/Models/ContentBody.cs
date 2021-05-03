using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class ContentBody
    {
        public int? ID { get; set; }
        [MaxLength(500)]
        public string? ImageURL { get; set; }

        [MaxLength(200)]
        public string? ImgDes { get; set; }
        [ForeignKey("Content")]
        public int? ContentID { get; set; }
        public string? Decription { get; set; }
        public byte? Deleted { get; set; }
    }
}
