﻿using Microsoft.AspNetCore.Http;
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
        [MaxLength(255)]
        [Required(ErrorMessage = "Subject name is required")]
        public string? Name { get; set; }
        [MaxLength(2000)]
        public string? Info { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageUrl { get; set; }
        [Range(0, 1000)]
        public int? BasicDuration { get; set; }
        [Range(0, 1000)]
        public int? AdvancedDuration { get; set; }
    }
}
