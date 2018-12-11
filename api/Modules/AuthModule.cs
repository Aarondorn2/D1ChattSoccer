using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Nancy;
using System.Linq;
using System.Net.Http;
using System.Text;
using D1SoccerApi.Entities;
using Nancy.ModelBinding;
using Newtonsoft.Json;

namespace D1SoccerApi.Modules {
    public class AuthModule : NancyModule {
        readonly IConfiguration Configuration;
        public AuthModule(D1SoccerApiContext ctx, IConfiguration config) : base("api") {
            Configuration = config;
			
	        Post("auth/facebook-connect", async (_, __) => {
				FbAuth auth = this.Bind();

				using (var client = new HttpClient()) {
					var resp = await client.GetAsync(auth.GetFormattedUrl());
					if (!resp.IsSuccessStatusCode) { return HttpStatusCode.BadRequest; }
					
					var email = JsonConvert.DeserializeAnonymousType(await resp.Content.ReadAsStringAsync(), new { Email = "" })?.Email;
					if (email == null) { return HttpStatusCode.BadRequest; }

					return GetToken(email, AuthProvider.Facebook, ctx);
				}
			});
			
	        Post("auth/google-oauth2", async (_, __) => {
		        GoogleAuth auth = this.Bind();
				
		        using (var client = new HttpClient()) {
					var content = JsonConvert.SerializeObject(new {
						code = auth.AuthorizationCode,
						client_id = Configuration["Google:ClientId"],
						client_secret = Configuration["Google:ClientSecret"],
						redirect_uri = Configuration["Google:AuthorizedRedirectUrl"],
						grant_type = "authorization_code"
					});

			        var resp = await client.PostAsync(GoogleAuth.TokenUrl, new StringContent(content, Encoding.UTF8, "application/json"));
			        if (!resp.IsSuccessStatusCode) { return HttpStatusCode.BadRequest; }
					
			        var jwt = JsonConvert.DeserializeAnonymousType(await resp.Content.ReadAsStringAsync(), new { id_token = "" })?.id_token;
			        if (jwt == null) { return HttpStatusCode.BadRequest; }
					
			        var email = new JwtSecurityTokenHandler().ReadJwtToken(jwt).Claims.First(x => x.Type == "email").Value;
			        if (email == null) { return HttpStatusCode.BadRequest; }
					
			        return GetToken(email, AuthProvider.Google, ctx);
		        }
	        });
        }

        string GetToken(string email, AuthProvider provider, D1SoccerApiContext ctx) {	
            var identity = ctx.Users
            .Where(x => x.Email == email)
            .Select(x => new JwtIdentity {
                Email = x.Email,
                Id = x.Id.ToString(),
                FirstName = x.FirstName,
                UserType = x.UserType,
				Provider = provider
            })
	        .FirstOrDefault() ?? new JwtIdentity { Email = email, Provider = provider };

            return Security.GenerateJWT(identity, Configuration["Secrets:JWT"]);
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
    }
}
