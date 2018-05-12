using Microsoft.Extensions.Configuration;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using System.IO;

namespace D1SoccerService {
    public class D1SoccerBootstrapper : DefaultNancyBootstrapper {
        readonly IConfiguration Configuration;
        public D1SoccerBootstrapper() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(RootPathProvider.GetRootPath())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container) {
            base.ConfigureApplicationContainer(container);
            container.Register(Configuration);
        }
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines) {
            base.ApplicationStartup(container, pipelines);
            pipelines.AfterRequest += ctx => {
                ctx.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                ctx.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, Authorization, x-token, x-appid");
                ctx.Response.Headers.Add("Access-Control-Allow-Methods", "OPTIONS, GET, POST, PUT, DELETE, PATCH");
            };
        }
    }

    public class D1SoccerRootPathProvider : IRootPathProvider {
        public string GetRootPath() {
            return Directory.GetCurrentDirectory();
        }
    }
}
