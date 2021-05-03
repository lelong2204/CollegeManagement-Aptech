using Microsoft.AspNetCore.Http;
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
        [Required(ErrorMessage = "Student code is required")]
        [MaxLength(255, ErrorMessage = "The maximum length of the code is 255")]
        public string? Code { get; set; }
        [MaxLength(500)]
        public string? Email { get; set; }
        [MaxLength(11)]
        public string? Phone { get; set; }
        [MaxLength(500, ErrorMessage = "The maximum length of the address is 500")]
        public string? Address { get; set; }
        public IFormFile Image { get; set; }
        [MaxLength(500, ErrorMessage = "The maximum length of the image url is 500")]
        public string? ImageURL { get; set; }
        public byte? Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        public int? Status { get; set; }
    }
}
