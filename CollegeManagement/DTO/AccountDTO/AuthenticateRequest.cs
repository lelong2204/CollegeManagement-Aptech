using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagement.DTO.AccountDTO
{
    public class AuthenticateRequest
    {
        [DisplayName("UserName")]
        [Required()]
        public string UserName { get; set; }

        [DisplayName("Password")]
        [Required()]
        public string Password { get; set; }
    }
}
