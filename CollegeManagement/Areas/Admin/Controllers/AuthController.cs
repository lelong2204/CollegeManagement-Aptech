using CollegeManagement.DTO.Account;
using CollegeManagement.Helper;
using CollegeManagement.Middleware;
using CollegeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : BaseController
    {
        private readonly DataContext _context;

        public AuthController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (UserLogin != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost, ActionName("Login")]
        public async Task<IActionResult> Login(AuthenticateRequest req)
        {
            try
            {
                var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName.ToLower().Equals(req.UserName.ToLower()) && u.Deleted != 1);

                if (user == null)
                {
                    TempData["Error"] = "Wrong username or password";
                    return RedirectToAction("Index");
                }

                if (!verifyPassword(req.Password, user.Password))
                {
                    TempData["Error"] = "Wrong username or password";
                    return RedirectToAction("Index");
                }

                var jwtToken = generateJwtToken(user);

                var response = new AuthenticateResponse
                {
                    FullName = user.FullName,
                    Id = user.ID,
                    UserName = user.UserName,
                    Token = jwtToken,
                };

                if (response != null)
                {
                    setTokenCookie(response.Token);
                    TempData["Success"] = MESSAGE_SUCCESS;
                    return RedirectToAction("Index", "Home");
                }

                TempData["Error"] = "Something wrong";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
            
        }

        private void setTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddYears(3)
            };
            Response.Cookies.Append("token", token, cookieOptions);
        }

        private bool verifyPassword(string password, string dbPassword)
        {
            //string hashPass = this.hashPassword(password);
            string hassMd5Pass = this.CreateMD5Hash(password);
            return hassMd5Pass.SequenceEqual(dbPassword);
        }

        public string CreateMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public IActionResult Logout(AuthenticateRequest req)
        {
            Response.Cookies.Delete("token");
            return RedirectToAction("Index");
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtMiddleware.SECRET_KEY);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("UserID", user.ID.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
