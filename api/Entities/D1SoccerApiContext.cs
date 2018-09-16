using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace D1SoccerApi.Entities {
    public partial class D1SoccerApiContext : DbContext {
        readonly IConfiguration Configuration;
        public D1SoccerApiContext(IConfiguration config) {
            Configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseMySql(Configuration.GetConnectionString("D1SoccerServiceContext"));
            }
        }
        
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ManualUserSeason> ManualUserSeasons { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<UserSeason> UserSeasons { get; set; }
        public virtual DbSet<Waiver> Waivers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }

    public class D1SoccerApiContextFactory : IDesignTimeDbContextFactory<D1SoccerApiContext> {
        public D1SoccerApiContext CreateDbContext(string[] args) {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            return new D1SoccerApiContext(config);
        }
    }
}
