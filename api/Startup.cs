using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nancy.Owin;

namespace D1SoccerApi {
    public class Startup {
        private readonly IConfiguration config;
        public Startup(IHostingEnvironment env) {
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath);
            config = builder.Build();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
            loggerFactory.AddConsole();

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseOwin(x => x.UseNancy());
        }
    }
}
