using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.DTO.Subject
{
    public class SubjectUpSertDTO
    {
        public int? ID { get; set; }
        [MaxLength(255, ErrorMessage = "Subject name max length is 255")]
        [Required(ErrorMessage = "Subject name is required")]
        public string? Name { get; set; }
        [MaxLength(2000, ErrorMessage = "Subject name max length is 255")]
        public string? Info { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageUrl { get; set; }
        [Range(0, 1000, ErrorMessage = "Basic duration must be between 0 and 1000")]
        public int? BasicDuration { get; set; }
        [Range(0, 1000, ErrorMessage = "Advanced duration must be between 0 and 1000")]
        public int? AdvancedDuration { get; set; }
    }
}
