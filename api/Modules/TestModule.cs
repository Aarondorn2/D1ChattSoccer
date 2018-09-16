using Nancy;
using Nancy.Security;
using System.Linq;
using D1SoccerApi.Entities;
using D1SoccerApi.Models;

namespace D1SoccerApi.Modules {
    public class TestModule : NancyModule {
        public TestModule(D1SoccerApiContext ctx) : base("api") {
            this.RequiresAuthentication();
           
            Get("/", _ => {
                return "hello world";
            });
            base.Get("/db", _ => {
                return JsonApi.Response(ctx.Users
                    .Select(x => new UserModel {
                        Id = x.Id.ToString(),
                        FirstName = x.FirstName,
                        LastName = x.LastName
                    })
                    .ToArray());
            });
            Get("/auth/test", _ => {
                return Context.CurrentUser.AsJwtIdentity().Email;
            });
        }
    }
}
