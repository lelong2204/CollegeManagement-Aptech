﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.DTO.Student
{
    public class StudentUpsertDTO
    {
        public int? ID { get; set; }
        [Required(ErrorMessage = "Student name is required")]
        [MaxLength(255, ErrorMessage = "The maximum length of the name is 255")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Father name is required")]
        [MaxLength(255, ErrorMessage = "The maximum length of the name is 255")]
        public string? FatherName { get; set; }

        [Required(ErrorMessage = "Mother name is required")]
        [MaxLength(255, ErrorMessage = "The maximum length of the name is 255")]
        public string? MotherName { get; set; }
        [Required(ErrorMessage = "Student code is required")]
        [MaxLength(20, ErrorMessage = "The maximum length of the code is 20")]
        public string? Code { get; set; }
        [MaxLength(500)]
        public string? Email { get; set; }
        [MaxLength(11)]
        public string? Phone { get; set; }
        [MaxLength(500, ErrorMessage = "The maximum length of the residential address is 500")]
        public string? ResidentialAddress { get; set; }
        [MaxLength(500, ErrorMessage = "The maximum length of the Permanent address is 500")]
        public string? PermanentAddress { get; set; }
        [MaxLength(500, ErrorMessage = "The maximum length of the image url is 500")]
        public string? ImageURL { get; set; }
        public IFormFile Image { get; set; }
        public byte? Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        public int? Status { get; set; }
        [Required(ErrorMessage = "The course is required")]
        public int? CourseID { get; set; }
        public int? Admission { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "The test score must be larger than 0")]
        public int? TestScore { get; set; }
    }
}
