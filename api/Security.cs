using Microsoft.IdentityModel.Tokens;
using Nancy.Authentication.Stateless;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace D1SoccerApi {
    public static class Security {
        private const string issuer = "D1ChattSoccer.com";
        private const string audience = "D1ChattSoccer.com";
        private const string authHeaderType = "Bearer ";

        public static string GenerateJWT(JwtIdentity identity, string jwtSecret) {
            if (identity == null || string.IsNullOrWhiteSpace(identity.Email)) { return null; }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var claims = new[] {
                new Claim("id", identity.Id),
                new Claim("user", identity.Email),
                new Claim("fname", identity.FirstName),
                new Claim("utype", identity.UserType)
            };
            
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static StatelessAuthenticationConfiguration GetAuthConfig(string jwtSecret) {
            return new StatelessAuthenticationConfiguration(ctx => {
                var authToken = ctx.Request.Headers.Authorization;
                if (authToken == null || !authToken.StartsWith(authHeaderType)) { return null; }
                
                var jwtToken = authToken.Substring(authHeaderType.Length);
                var tokenHandler = new JwtSecurityTokenHandler();
                if (!tokenHandler.CanReadToken(jwtToken)) { return null; }

                try {
                    var claims = tokenHandler.ValidateToken(jwtToken,
                        new TokenValidationParameters {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = issuer,
                            ValidAudience = audience,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
                        },
                        out var _);

                    if (string.IsNullOrWhiteSpace(claims?.AsJwtIdentity()?.Email)) { return null; }
                    return claims;
                } catch {
                    return null;
                }
            });
        }
    }

    public class JwtIdentity : ClaimsPrincipal {
        public JwtIdentity() : base() { }
        public JwtIdentity(ClaimsPrincipal principal) : base(principal) {
            Id = FindFirst("id")?.Value;
            Email = FindFirst("user")?.Value;
            FirstName = FindFirst("fname")?.Value;
            UserType = FindFirst("utype")?.Value;
            IsRegistered = bool.TryParse(FindFirst("regd")?.Value, out var isRegistered) ? isRegistered : false;
            IsVerified = bool.TryParse(FindFirst("vrfd")?.Value, out var isVerified) ? isVerified : false;
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string UserType { get; set; }
        public bool IsRegistered { get; set; }
        public bool IsVerified { get; set; }
    }
}
