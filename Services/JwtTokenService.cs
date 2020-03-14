using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace JwtTokenDemo.Services
{
    public class JwtTokenService:IJwtTokenService
    {
        public string GenerateToken (int id, int userId, string userType,string key) {
            var tokenHandler = new JwtSecurityTokenHandler ();
            var keyBytes = Encoding.ASCII.GetBytes (key);

            var tokenDescriptor = new SecurityTokenDescriptor ();
            var claimId = tokenDescriptor.Subject = new ClaimsIdentity ();
            claimId.AddClaim (new Claim (ClaimTypes.NameIdentifier, id.ToString()));
            claimId.AddClaim (new Claim (ClaimTypes.Name, userId.ToString()));
            claimId.AddClaim (new Claim (ClaimTypes.Role, userType));

            tokenDescriptor.Expires = DateTime.UtcNow.AddHours (24);
            tokenDescriptor.SigningCredentials = new SigningCredentials (
                new SymmetricSecurityKey (keyBytes),
                SecurityAlgorithms.HmacSha512Signature);

            var token = tokenHandler.CreateToken (tokenDescriptor);
            var tokenString = tokenHandler.WriteToken (token);
            return tokenString;
        }

        public string GenerateToken(int id, int userId, string userType, string key, int expiredTimeInHours)
        {
            var tokenHandler = new JwtSecurityTokenHandler ();
            var keyBytes = Encoding.ASCII.GetBytes (key);

            var tokenDescriptor = new SecurityTokenDescriptor ();
            var claimId = tokenDescriptor.Subject = new ClaimsIdentity ();
            claimId.AddClaim (new Claim (ClaimTypes.NameIdentifier, id.ToString()));
            claimId.AddClaim (new Claim (ClaimTypes.Name, userId.ToString()));
            claimId.AddClaim (new Claim (ClaimTypes.Role, userType));

            tokenDescriptor.Expires = DateTime.UtcNow.AddHours (expiredTimeInHours);
            tokenDescriptor.SigningCredentials = new SigningCredentials (
                new SymmetricSecurityKey (keyBytes),
                SecurityAlgorithms.HmacSha512Signature);

            var token = tokenHandler.CreateToken (tokenDescriptor);
            var tokenString = tokenHandler.WriteToken (token);
            return tokenString;
        }
    }
}
