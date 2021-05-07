using System.ComponentModel;

namespace CollegeManagement.DTO.Account
{
    public class AuthenticateRequest
    {
        [DisplayName("UserName")]
        public string UserName { get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }
    }
}
