using D1SoccerService.Entities;
using D1SoccerService.Models;
using Nancy;
using Newtonsoft.Json;
using System.Linq;

namespace D1SoccerService.Modules {
    public class TestModule : NancyModule {
        public TestModule(D1SoccerServiceContext ctx) : base("api") {
            Get("/", _ => {
                return "hello there";
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
            Get("/db2", _ => {
                return JsonApi.Response(ctx.Users
                    .Select(x => new User {
                        Id = x.Id.ToString(),
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Dob = x.Dob,
                        Gender = x.Gender
                    })
                    .FirstOrDefault());
            });
        }
    }
}
