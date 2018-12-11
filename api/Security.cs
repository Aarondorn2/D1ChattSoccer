using Microsoft.IdentityModel.Tokens;
using Nancy.Authentication.Stateless;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using D1SoccerApi.Entities;
using D1SoccerApi.Modules;

namespace D1SoccerApi {
    public static class Security {
        const string issuer = "D1ChattSoccer.com";
        const string audience = "D1ChattSoccer.com";
        const string authHeaderType = "Bearer ";

        public static string GenerateJWT(JwtIdentity identity, string jwtSecret) {
            if (identity == null || string.IsNullOrWhiteSpace(identity.Email)) { return null; }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var claims = new[] {
                new Claim("id", identity.Id),
                new Claim("user", identity.Email),
                new Claim("fname", identity.FirstName),
                new Claim("utype", ((int)identity.UserType).ToString()),
	            new Claim("prov", ((int)identity.Provider).ToString())
            };
            
            var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.UtcNow.AddMonths(1), signingCredentials: creds);

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
                    var claims = tokenHandler.ValidateToken(
	                    jwtToken,
                        new TokenValidationParameters {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = issuer,
                            ValidAudience = audience,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
                        },
                        out _);

                    return string.IsNullOrWhiteSpace(claims.AsJwtIdentity()?.Email)
		                ? null
		                : claims;
                } catch {
                    return null;
                }
            });
        }
    }

    public class JwtIdentity : ClaimsPrincipal {
	    public JwtIdentity() { }
	    public JwtIdentity(ClaimsPrincipal principal) : base(principal) {
            Id = FindFirst("id")?.Value;
            Email = FindFirst("user")?.Value;
            FirstName = FindFirst("fname")?.Value;
            UserType = int.TryParse(FindFirst("utype")?.Value, out var utype) ? (UserType)utype : UserType.Player;
		    Provider = int.TryParse(FindFirst("prov")?.Value, out var prov) ? (AuthModule.AuthProvider)prov : AuthModule.AuthProvider.Unspecified;
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public UserType UserType { get; set; }
		public AuthModule.AuthProvider Provider { get; set; }
    }
}
