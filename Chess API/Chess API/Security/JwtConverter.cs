using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Chess_API.Security
{
    public class JwtConverter
    {
        private readonly SymmetricSecurityKey key;
        private readonly string ISSUER = "chess_game";
        private readonly int EXPIRATION_MINUTES = 15;
        private readonly int EXPIRATION_MILLIS = 15 * 60 * 1000;

        public JwtConverter()
        {
            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key_here")); // Replace with your own secret key
        }

        public string GetTokenFromUser(AppUser user)
        {
            var claims = user.GetClaims();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = ISSUER,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(EXPIRATION_MINUTES),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public AppUser GetUserFromToken(string token)
        {
            if (token == null || !token.StartsWith("Bearer "))
            {
                return null;
            }

            token = token.Substring(7);

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = key,
                    ValidIssuer = ISSUER,
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                };

                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out _);
                var appUserId = int.Parse(claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier));
                var username = claimsPrincipal.FindFirstValue(ClaimTypes.Name);
                var roles = AppUser.ConvertAuthoritiesToRoles(claimsPrincipal.Claims);

                return new AppUser(appUserId, username, roles);
            }
            catch (SecurityTokenException)
            {
                // Token validation failed, return null or handle the error
                return null;
            }
        }
    }
}
