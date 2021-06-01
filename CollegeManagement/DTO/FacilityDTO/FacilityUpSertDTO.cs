using CollegeManagement.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.DTO.FacilityDTO
{
    public class FacilityUpSertDTO
    {
        public int? ID { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }
        public int? Qty { get; set; }
        [MaxLength(1000)]
        public string? Info { get; set; }
        public List<FacilityImg> ImgUrls { get; set; }
        public List<int> ImgsDelete { get; set; }
        public List<IFormFile> Imgs { get; set; }
    }
}
