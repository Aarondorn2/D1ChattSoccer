using Microsoft.Extensions.Configuration;
using Nancy;
using System.Linq;
using D1SoccerApi.Entities;

namespace D1SoccerApi.Modules {
    public class AuthModule : NancyModule {
        readonly IConfiguration Configuration;
        public AuthModule(D1SoccerApiContext ctx, IConfiguration config) : base("api") {
            Configuration = config;

            Get("/auth", _ => {
                return GetToken("aarondorn2@gmail.com", ctx);
            });
        }

        private string GetToken(string email, D1SoccerApiContext ctx) {
            var identity = ctx.Users
            .Where(x => x.Email == email)
            .Select(x => new JwtIdentity {
                Email = x.Email,
                Id = x.Id.ToString(),
                FirstName = x.FirstName,
                UserType = x.UserType.ToString(),
                IsVerified = x.IsEmailVerified,
                IsRegistered = true
            }).FirstOrDefault() ?? new JwtIdentity {
                Email = email,
                IsRegistered = false
            };
            return Security.GenerateJWT(identity, Configuration["Secrets:JWT"]);
        }
    }
}
