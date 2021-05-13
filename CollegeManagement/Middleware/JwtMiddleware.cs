using CollegeManagement.DTO.Account;
using CollegeManagement.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        public const string SECRET_KEY = "asdnasdf adg asdgasd gasdg sadgasdg";

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, DataContext dataContext)
        {
            var jwtToken = context.Request.Cookies["collegeusertoken"];
            var authorization = context.Request.Headers["Authorization"].FirstOrDefault();

            if (!String.IsNullOrEmpty(jwtToken))
            {
                context.Request.Headers["Authorization"] = "Bearer " + jwtToken;
                await attachAccountToContext(context, dataContext, jwtToken);
            }

            await _next(context);
        }

        private async Task attachAccountToContext(HttpContext context, DataContext dataContext, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(SECRET_KEY);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userID = int.Parse(jwtToken.Claims.First(x => x.Type == "UserID").Value);
                var user = await dataContext.Users.FirstOrDefaultAsync(x => x.ID == userID && x.Deleted != 1);
                AccountLogin accountLogin = null;

                if (user != null)
                {
                    if (user.Role == "Faculty")
                    {
                        var faculty = await dataContext.Faculties.FirstOrDefaultAsync(f => f.Deleted != 1 && f.UserID == user.ID);
                        if (faculty == null)
                        {
                            context.Response.Redirect("/Admin/Auth/Logout");
                        }
                        else
                        {
                            user.PhoneNumber = faculty.PhoneNumber;
                            user.Address = faculty.Address;
                            user.FullName = faculty.Name;
                            user.Email = faculty.Email;
                        }
                    }
                    else if (user.Role == "Student")
                    {
                        var student = await dataContext.Students.FirstOrDefaultAsync(f => f.Deleted != 1 && f.UserID == user.ID);
                        if (student == null)
                        {
                            context.Response.Redirect("/Admin/Auth/Logout");
                        }
                        else
                        {
                            user.PhoneNumber = student.PhoneNumber;
                            user.Address = student.PermanentAddress;
                            user.FullName = student.Name;
                            user.Email = student.Email;
                        }
                    }

                    accountLogin = new AccountLogin(user);
                }
                else
                {
                    context.Response.Redirect("/Admin/Auth/Logout");
                }

                context.Items["UserLogin"] = accountLogin;
            }
            catch (Exception ex)
            {
                // do nothing if jwt validation fails
                // account is not attached to context so request won't have access to secure routes
                // throw new AppException(ex.Message);
                context.Items["UserLogin"] = null;
            }
        }
    }
}
