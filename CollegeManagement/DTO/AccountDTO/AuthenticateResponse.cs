using System.ComponentModel;

namespace CollegeManagement.DTO.AccountDTO
{
    public class AuthenticateResponse
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("UserName")]
        public string UserName { get; set; }

        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [DisplayName("Token")]
        public string Token { get; set; }
    }
}
