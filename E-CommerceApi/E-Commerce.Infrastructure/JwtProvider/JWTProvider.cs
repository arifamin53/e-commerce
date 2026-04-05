using E_Commerce.Application.Abstraction.IJWTProvider;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using E_commerce.Domain.Entities;

namespace E_Commerce.Infrastructure.JwtProvider
{
    public class JWTProvider(IConfiguration configuration) : IJWTProvider
    {
        public string GenerateAuthToken(User user)
        {
            var descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new List<Claim>
                {
                   new Claim(UserClaims.UserId,user.Id.ToString()),
                   new Claim(UserClaims.ContactNo,user.ContactNo),
                   new Claim(JwtRegisteredClaimNames.Email,user.Email)
                }),
                Expires = DateTime.UtcNow.AddMonths(1),
                Issuer = configuration["JWt:Issuer"],
                Audience = configuration["JWT:Audience"],
                SigningCredentials=new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!)),
                    SecurityAlgorithms.HmacSha256
               )

            };
            var tokenhandler=new JwtSecurityTokenHandler();
            var tokenDescriptor = tokenhandler.CreateToken(descriptor);
            var token=tokenhandler.WriteToken(tokenDescriptor);
            return token;
        }
    }
}
