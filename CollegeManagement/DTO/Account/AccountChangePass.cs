using CollegeManagement.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagement.DTO.Account
{
    public class AccountChangePass
    {
        [Required()]
        [MinLength(8, ErrorMessage = "Password min length is 8 characters")]
        [MaxLength(64, ErrorMessage = "Password min length is 8 characters")]
        public string NewPassword { get; set; }
        [Required()]
        public string CurrentPassword { get; set; }
    }
}
