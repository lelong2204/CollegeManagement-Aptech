using CollegeManagement.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagement.DTO.Account
{
    public class AccountChangePass
    {
        [Required()]
        [MinLength(8)]
        [MaxLength(64)]
        public string NewPassword { get; set; }
        [Required()]
        public string CurrentPassword { get; set; }
    }
}
