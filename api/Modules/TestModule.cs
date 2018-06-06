using D1SoccerApi;
using D1SoccerService.Entities;
using D1SoccerService.Models;
using Nancy;
using Nancy.Security;
using System.Linq;

namespace D1SoccerService.Modules {
    public class TestModule : NancyModule {
        public TestModule(D1SoccerApiContext ctx) : base("api") {
            this.RequiresAuthentication();
           
            Get("/", _ => {
                return "hello world";
            });
            Get("/db", _ => {
                return JsonApi.Response(ctx.Users
                    .Select(x => new User {
                        Id = x.Id.ToString(),
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Dob = x.Dob,
                        Gender = x.Gender
                    })
                    .ToArray());
            });
            Get("/auth/test", _ => {
                return Context.CurrentUser.AsJwtIdentity().Email;
            });
        }
    }
}
