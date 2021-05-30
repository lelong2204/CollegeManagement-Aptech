﻿using CollegeManagement.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagement.DTO.FacilityDTO
{
    public class FacilityUpSertDTO
    {
        public int? Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }
        public int? Qty { get; set; }
        [MaxLength(1000)]
        public string? Info { get; set; }
        public List<FacilityImg> ImgUrls { get; set; }
        public List<IFormFile> Imgs { get; set; }
    }
}
