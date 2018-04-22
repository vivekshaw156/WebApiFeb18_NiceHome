using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace MyNiceHome.BusinessManager.MyNiceHome.BusinessManager.Helpers
{
    public class JwtTokenHelper
    {
        public string GenerateToken(string email, string role)
        {
            DateTime issuedAt = DateTime.UtcNow;
            DateTime expiresAt = DateTime.UtcNow.AddDays(7);

            var tokenHandler = new JwtSecurityTokenHandler();

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email,email),
                new Claim(ClaimTypes.Role, role)
            });

            const string secretHash = "WYKgonnAkp09g12eoZgkD0fF4sqZk9dZNaxgfX6vjwKtYUeHWvsbuuFF8lx3LrBkzy3gvXWmaBqivtkVoF7EPak6DiJ4INin6VLk";

            var now = DateTime.UtcNow;

            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretHash));

            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            //create the jwt
            var token = (JwtSecurityToken) tokenHandler.CreateJwtSecurityToken(
                issuer: "http://localhost:00000",
                audience: "http://localhost:2400",
                subject: claimsIdentity,
                notBefore: issuedAt,
                expires: expiresAt,
                signingCredentials: signingCredentials);

            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
