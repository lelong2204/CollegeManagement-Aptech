using CollegeManagement.Models;
using System;

namespace CollegeManagement.DTO.Account
{
    public class AccountLogin
    {
        public int? ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImageURL { get; set; }

        public AccountLogin()
        {

        }

        public AccountLogin(User user)
        {
            if (user != null)
            {
                ID = user.ID;
                UserName = user.UserName;
                Password = user.Password;
                FullName = user.FullName;
                Phone = user.PhoneNumber;
                Email = user.Email;
                Address = user.Address;
                ImageURL = user.ImageURL;
            }
        }
    }
}
