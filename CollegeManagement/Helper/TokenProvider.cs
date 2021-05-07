using CollegeManagement.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HVB.ePICOS.WA.Helpers
{
    public static class TokenProvider
    {
        public static string GetToken(this User user, string secretKey)
        {
            if (user == null)
            {
                return null;
            }

            var key = Encoding.ASCII.GetBytes(secretKey);
            var JWToken = new JwtSecurityToken(
                claims: GetUserClaims(user),
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature)
            );
            var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
            return token;
        }

        private static IEnumerable<Claim> GetUserClaims(User user)
        {
            IEnumerable<Claim> claims = new Claim[]
            {
                new Claim("UserID", user.ID.ToString()),
                new Claim("UserName", user.UserName),
                new Claim("Password", user.Password)
            };
            return claims;
        }
    }
}
