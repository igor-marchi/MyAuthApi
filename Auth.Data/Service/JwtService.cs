using Auth.Core.Domain;
using Auth.Infra.Interface.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Auth.Data.Service
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration configuration;

        public JwtService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(TokenConfig(user));
            return tokenHandler.WriteToken(token);
        }

        private SecurityTokenDescriptor TokenConfig(User user)
        {
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("Jwt:Secret").Value);
            //var audience = configuration.GetSection("Jwt:Audience").Value;
            //var issuer = configuration.GetSection("Jwt:Issuer").Value;
            var expires = configuration.GetSection("Jwt:Expires").Value;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()), //User.Identity.Name
                new Claim(ClaimTypes.Email, user.Email), //User.Identity.Email
            };

            claims.AddRange(user.Roles.Select(x => new Claim(ClaimTypes.Role, x.Description))); //User.Identity.Role

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                //Audience = audience,
                //Issuer = issuer,
                Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(expires)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            return tokenDescriptor;
        }
    }
}