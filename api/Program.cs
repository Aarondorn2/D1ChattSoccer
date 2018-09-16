﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace D1SoccerApi {
    public class Program {
        public static IConfiguration Configuration { get; set; }

        public static void Main(string[] args) {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) {
            return WebHost.CreateDefaultBuilder(args)
                //.UseContentRoot(Directory.GetCurrentDirectory())
                //.UseKestrel()
                .UseStartup<Startup>()
                .Build();
        }
    }
}
