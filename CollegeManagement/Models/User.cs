using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class User : BaseModel
    {
        public enum ROLETYPE
        {
            Admin,
            Teacher,
            Student
        }

        [Required(ErrorMessage = "User name is required")]
        [MaxLength(64, ErrorMessage = "The maximum length of the user name is 64")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MaxLength(255, ErrorMessage = "The maximum length of the password is 255")]
        public string Password { get; set; }
        public int? RoleType { get; set; }
    }
}
