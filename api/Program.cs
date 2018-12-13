using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace D1SoccerApi {
    public class Program {
        public static IConfiguration Configuration { get; set; }

        public static void Main(string[] args) {
	        CreateWebHostBuilder(args).Build().Run();
        }

	    public static IWebHostBuilder CreateWebHostBuilder(string[] args) {
		    return WebHost.CreateDefaultBuilder(args)
			    .UseStartup<Startup>();
	    }
    }
}
