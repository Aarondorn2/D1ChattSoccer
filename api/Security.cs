using Microsoft.IdentityModel.Tokens;
using Nancy.Authentication.Stateless;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using D1SoccerApi.Entities;
using D1SoccerApi.Modules;

namespace D1SoccerApi {
    public static class Security {
        const string ISSUER = "D1ChattSoccer.com";
        const string AUDIENCE = "D1ChattSoccer.com";
        const string AUTH_HEADER_TYPE = "Bearer ";

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
            
            var token = new JwtSecurityToken(ISSUER, AUDIENCE, claims, expires: DateTime.UtcNow.AddMonths(1), signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static StatelessAuthenticationConfiguration GetAuthConfig(string jwtSecret) {
            return new StatelessAuthenticationConfiguration(ctx => {
                var authToken = ctx.Request.Headers.Authorization;
                if (authToken == null || !authToken.StartsWith(AUTH_HEADER_TYPE)) { return null; }
                
                var jwtToken = authToken.Substring(AUTH_HEADER_TYPE.Length);
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
                            ValidIssuer = ISSUER,
                            ValidAudience = AUDIENCE,
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

	    public static string Encrypt(string data, string key) {
		    using (var des = new TripleDESCryptoServiceProvider { Mode = CipherMode.ECB, Key = Encoding.UTF8.GetBytes(key), Padding = PaddingMode.PKCS7 })
		    using (var desEncrypt = des.CreateEncryptor()) {
			    var buffer = Encoding.UTF8.GetBytes(data);

			    return Convert.ToBase64String(desEncrypt.TransformFinalBlock(buffer, 0, buffer.Length));
		    }
	    }

	    public static string Decrypt(string encryptedData, string key) {
		    using (var des = new TripleDESCryptoServiceProvider { Mode = CipherMode.ECB, Key = Encoding.UTF8.GetBytes(key), Padding = PaddingMode.PKCS7 })
		    using (var desEncrypt = des.CreateDecryptor()) {
			    var buffer = Convert.FromBase64String(encryptedData.Replace(" ", "+"));

			    return Encoding.UTF8.GetString(desEncrypt.TransformFinalBlock(buffer, 0, buffer.Length));
		    }
	    }

	    public static class Credential {
		    public static bool IsValid(string email, string password, string credentialSecret, D1SoccerApiContext ctx) {
			    var credPass = ctx.Credentials
				    .Where(x => x.Email == email)
				    .Select(x => x.Password)
				    .FirstOrDefault();

			    return credPass != null && BCrypt.Net.BCrypt.Verify(password, Decrypt(credPass, credentialSecret));
		    }

		    public static void Add(string email, string password, string credentialSecret, D1SoccerApiContext ctx) {
				ctx.Credentials.Add(new Entities.Credential {
					Email = email,
					Password = Encrypt(BCrypt.Net.BCrypt.HashPassword(password), credentialSecret),
					LastLogin = DateTime.UtcNow
				});
		    }
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
