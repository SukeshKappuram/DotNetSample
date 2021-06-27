using Microsoft.IdentityModel.Tokens;
using ProductAPI.Models.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Business.User
{
    public class SecurityManager:ISecurityManager
    {
        private JwtSettings _settings;

        public SecurityManager(JwtSettings settings)
        {
            _settings = settings;
        }

        public void BuildUserAuthObject(AppUserAuth authUser)
        {
            authUser.BearerToken = BuildJwtToken(authUser);
        }

        protected string BuildJwtToken(AppUserAuth authUser)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));

            // Create standard JWT claims
            List<Claim> jwtClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, authUser.EmailAddress),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
              
                // Add custom claims
                new Claim("isAuthenticated", "true"),
                new Claim("userId", authUser.Id.ToString())
            };

            foreach (var role in authUser.UserRoles)
            {
                jwtClaims.Add(new Claim(ClaimTypes.Role, role.RoleName));
            }

            // Create the JwtSecurityToken object
            var token = new JwtSecurityToken(
              issuer: _settings.Issuer,
              audience: _settings.Audience,
              claims: jwtClaims,
              notBefore: DateTime.UtcNow,
              expires: DateTime.UtcNow.AddMinutes(
                  _settings.MinutesToExpiration),
              signingCredentials: new SigningCredentials(key,
                          SecurityAlgorithms.HmacSha256)
            );

            // Create a string representation of the Jwt token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string ExtendJwtTokenExpiration(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.ReadJwtToken(token);

            // Create a string representation of the Jwt token
            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
              issuer: _settings.Issuer,
              audience: _settings.Audience,
              claims: securityToken.Claims,
              notBefore: DateTime.UtcNow,
              expires: DateTime.UtcNow.AddMinutes(
                  _settings.MinutesToExpiration),
              signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key)),
                          SecurityAlgorithms.HmacSha256)
            ));
        }
    }
}
