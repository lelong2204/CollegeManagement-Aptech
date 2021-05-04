using CollegeManagement.DTO.Departments;
using CollegeManagement.DTO.Subject;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.DTO.Course
{
    public class CourseUpSertDTO
    {
        public int? ID { get; set; }
        [Required(ErrorMessage = "Course name is required")]
        [MaxLength(255, ErrorMessage = "Course name max length is 255")]
        public string? Name { get; set; }
        public string? Info { get; set; }
        public IFormFile Image { get; set; }
        public string ImageURL { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater than or equal 0")]
        public int? Price { get; set; }
        public byte? Focus { get; set; }
        public List<int> SubjectIDs { get; set; }
        public IQueryable<SubjectSelectDTO> SubjectList { get; set; }
        [Required(ErrorMessage = "Department is required")]
        public int? DepartmentID { get; set; }
        public IQueryable<DepartmentSelectDTO> DepartmentList { get; set; }
    }
}
