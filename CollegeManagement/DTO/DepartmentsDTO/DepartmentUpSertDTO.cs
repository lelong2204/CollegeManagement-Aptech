using System.ComponentModel.DataAnnotations;

namespace CollegeManagement.DTO.DepartmentsDTO
{
    public class DepartmentUpSertDTO
    {
        public int? ID { get; set; }
        [Required()]
        [MaxLength(255)]
        public string? Name { get; set; }
        [Required()]
        [MaxLength(2000)]
        public string? Info { get; set; }
    }
}
