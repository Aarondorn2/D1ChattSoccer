using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Nancy;
using System.Linq;
using System.Net.Http;
using System.Text;
using D1SoccerApi.Entities;
using Nancy.ModelBinding;
using Newtonsoft.Json;
using Z.EntityFramework.Plus;

namespace D1SoccerApi.Modules {
    public class AuthModule : NancyModule {
        public AuthModule(D1SoccerApiContext ctx, IConfiguration config) : base("api") {
			Post("auth/email", _ => {
				EmailAuth auth = this.Bind();
				var tenMinutesAgo = DateTime.UtcNow.AddMinutes(-10);

				if (!Validate.IsValidEmail(auth.Email) || !Validate.IsValidPassword(auth.Password)) {
					return HttpStatusCode.BadRequest;
				}

				if (ctx.FailedLogins.Count(y => y.Email == auth.Email && y.Attempt > tenMinutesAgo) >= 10) {
					return HttpStatusCode.TooManyRequests;
				}
			
				if (Security.Credential.IsValid(auth.Email, auth.Password, config["Secrets:Credentials"], ctx)) {
					ctx.Credentials.Where(x => x.Email == auth.Email)
						.Update(x => new Credential {
							LastLogin = DateTime.UtcNow
						});

					return GetToken(auth.Email, AuthProvider.EmailUnverified, config["Secrets:JWT"], ctx);
				}

				ctx.FailedLogins.Add(new FailedLogin {
					Email = auth.Email,
					Attempt = DateTime.UtcNow
				});
				ctx.SaveChanges();

				return HttpStatusCode.BadRequest;
			});
			
	        Post("auth/facebook-connect", async (_, __) => {
				FbAuth auth = this.Bind();

				using (var client = new HttpClient()) {
					var resp = await client.GetAsync(auth.GetFormattedUrl());
					if (!resp.IsSuccessStatusCode) { return HttpStatusCode.BadRequest; }
					
					var email = JsonConvert.DeserializeAnonymousType(await resp.Content.ReadAsStringAsync(), new { Email = "" })?.Email;
					if (email == null) { return HttpStatusCode.BadRequest; }

					return GetToken(email, AuthProvider.Facebook, config["Secrets:JWT"], ctx);
				}
			});
			
	        Post("auth/google-oauth2", async (_, __) => {
		        GoogleAuth auth = this.Bind();
				
		        using (var client = new HttpClient()) {
					var content = JsonConvert.SerializeObject(new {
						code = auth.AuthorizationCode,
						client_id = config["Google:ClientId"],
						client_secret = config["Google:ClientSecret"],
						redirect_uri = config["Google:AuthorizedRedirectUrl"],
						grant_type = "authorization_code"
					});

			        var resp = await client.PostAsync(GoogleAuth.TokenUrl, new StringContent(content, Encoding.UTF8, "application/json"));
			        if (!resp.IsSuccessStatusCode) { return HttpStatusCode.BadRequest; }
					
			        var jwt = JsonConvert.DeserializeAnonymousType(await resp.Content.ReadAsStringAsync(), new { id_token = "" })?.id_token;
			        if (jwt == null) { return HttpStatusCode.BadRequest; }
					
			        var email = new JwtSecurityTokenHandler().ReadJwtToken(jwt).Claims.First(x => x.Type == "email").Value;
			        if (email == null) { return HttpStatusCode.BadRequest; }
					
			        return GetToken(email, AuthProvider.Google, config["Secrets:JWT"], ctx);
		        }
	        });
        }

        string GetToken(string email, AuthProvider provider, string jwtSecret, D1SoccerApiContext ctx) {	
            var user = ctx.Users
            .Where(x => x.Email == email)
            .Select(x => new {
                x.Id,
                x.Email,
                x.FirstName,
                x.UserType,
				x.IsEmailVerified
            })
	        .FirstOrDefault();

            return Security.GenerateJWT(
	            new JwtIdentity {
		            Email = email,
		            Id = user?.Id.ToString(),
		            FirstName = user?.FirstName,
		            UserType = user?.UserType ?? UserType.Player,
		            Provider = provider == AuthProvider.EmailUnverified && user?.IsEmailVerified == true
			            ? AuthProvider.EmailVerified
			            : provider
	            },
	            jwtSecret);
        }

	    public enum AuthProvider {
			Unspecified,
			Facebook,
			Google,
			EmailUnverified,
			EmailVerified
	    }

	    class FbAuth {
		    const string Url = "https://graph.facebook.com/v3.2";

			public string UserId { get; set; }
		    public string AccessToken { get; set; }

		    public string GetFormattedUrl() => $"{Url}/{UserId}?access_token={AccessToken}&fields=email";
	    }

	    class GoogleAuth {
		    const string Url = "https://www.googleapis.com/oauth2";
		    public static readonly string TokenUrl = $"{Url}/v4/token";

		    public string AuthorizationCode { get; set; }
	    }

	    class EmailAuth {
			public string Email { get; set; }
		    public string Password { get; set; }
	    }
    }
}
