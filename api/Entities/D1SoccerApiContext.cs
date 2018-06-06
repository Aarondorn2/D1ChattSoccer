using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace D1SoccerService.Entities {
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

        public virtual DbSet<Announcements> Announcements { get; set; }
        public virtual DbSet<CachedUsers> Cachedusers { get; set; }
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<ManualUserSeasons> ManualUserSeasons { get; set; }
        public virtual DbSet<Seasons> Seasons { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserSeasons> UserSeasons { get; set; }
        public virtual DbSet<Waivers> Waivers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Announcements>(entity => {
                entity.ToTable("announcements");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content");

                entity.Property(e => e.SystemLoadDate)
                    .HasColumnName("system_load_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CachedUsers>(entity => {
                entity.ToTable("cached_users");

                entity.HasIndex(e => e.Token)
                    .HasName("indx_token");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CacheTime)
                    .HasColumnName("cache_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("token")
                    .HasMaxLength(255);

                entity.Property(e => e.Uid)
                    .IsRequired()
                    .HasColumnName("uid")
                    .HasMaxLength(100);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Contracts>(entity => {
                entity.ToTable("contracts");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContractDisplayName)
                    .IsRequired()
                    .HasColumnName("contract_display_name")
                    .HasMaxLength(100);

                entity.Property(e => e.ContractName)
                    .IsRequired()
                    .HasColumnName("contract_name")
                    .HasMaxLength(100);

                entity.Property(e => e.ContractText)
                    .IsRequired()
                    .HasColumnName("contract_text");

                entity.Property(e => e.ContractValidEndDate)
                    .HasColumnName("contract_valid_end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContractValidStartDate)
                    .HasColumnName("contract_valid_start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SystemLoadDate)
                    .HasColumnName("system_load_date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<ManualUserSeasons>(entity => {
                entity.ToTable("manual_user_seasons");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HasPaid)
                    .HasColumnName("has_paid")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.HasTeam)
                    .HasColumnName("has_team")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.HasWaiver)
                    .HasColumnName("has_waiver")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("payment_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SeasonId)
                    .HasColumnName("season_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SystemLoadDate)
                    .HasColumnName("system_load_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SystemUpdateDate)
                    .HasColumnName("system_update_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TeamId)
                    .HasColumnName("team_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Seasons>(entity => {
                entity.ToTable("seasons");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.RegistrationEndDate)
                    .HasColumnName("registration_end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RegistrationStartDate)
                    .HasColumnName("registration_start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SystemLoadDate)
                    .HasColumnName("system_load_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SystemUpdateDate)
                    .HasColumnName("system_update_date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Teams>(entity => {
                entity.ToTable("teams");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CaptainFirstName)
                    .IsRequired()
                    .HasColumnName("captain_first_name")
                    .HasMaxLength(255);

                entity.Property(e => e.CaptainId)
                    .HasColumnName("captain_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CaptainLastName)
                    .IsRequired()
                    .HasColumnName("captain_last_name")
                    .HasMaxLength(255);

                entity.Property(e => e.SystemLoadDate)
                    .HasColumnName("system_load_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SystemUpdateDate)
                    .HasColumnName("system_update_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TeamColor)
                    .IsRequired()
                    .HasColumnName("team_color")
                    .HasMaxLength(55);

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasColumnName("team_name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Users>(entity => {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("indx_email");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.IsEmailVerified)
                    .HasColumnName("is_email_verified")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.EmergencyContact)
                    .IsRequired()
                    .HasColumnName("emergency_contact")
                    .HasMaxLength(255);

                entity.Property(e => e.EmergencyContactPhone)
                    .IsRequired()
                    .HasColumnName("emergency_contact_phone")
                    .HasMaxLength(20);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(20);

                entity.Property(e => e.IsDefense)
                    .HasColumnName("is_defense")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IsKeeper)
                    .HasColumnName("is_keeper")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IsOffense)
                    .HasColumnName("is_offense")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(20);

                entity.Property(e => e.ShirtSize)
                    .HasColumnName("shirt_size")
                    .HasMaxLength(20);

                entity.Property(e => e.SystemLoadDate)
                    .HasColumnName("system_load_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SystemUpdateDate)
                    .HasColumnName("system_update_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasColumnName("user_type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserSeasons>(entity => {
                entity.ToTable("user_seasons");

                entity.HasIndex(e => e.UserId)
                    .HasName("IDX_E728F53EA76ED395");

                entity.HasIndex(e => e.WaiverId)
                    .HasName("UNIQ_E728F53EA43B7175")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HasPaid)
                    .HasColumnName("has_paid")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.HasTeam)
                    .HasColumnName("has_team")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.HasWaiver)
                    .HasColumnName("has_waiver")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("payment_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SeasonId)
                    .HasColumnName("season_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SystemLoadDate)
                    .HasColumnName("system_load_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SystemUpdateDate)
                    .HasColumnName("system_update_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TeamId)
                    .HasColumnName("team_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.WaiverId)
                    .HasColumnName("waiver_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSeasons)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_E728F53EA76ED395");

                entity.HasOne(d => d.Waiver)
                    .WithOne(p => p.UserSeason)
                    .HasForeignKey<UserSeasons>(d => d.WaiverId)
                    .HasConstraintName("FK_E728F53EA43B7175");
            });

            modelBuilder.Entity<Waivers>(entity => {
                entity.ToTable("waivers");

                entity.HasIndex(e => e.ContractId)
                    .HasName("IDX_B364E1BE2576E0FD");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AcceptedDate)
                    .HasColumnName("accepted_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.AcceptedEmail)
                    .IsRequired()
                    .HasColumnName("accepted_email")
                    .HasMaxLength(255);

                entity.Property(e => e.AcceptedIpaddress)
                    .IsRequired()
                    .HasColumnName("accepted_ipaddress")
                    .HasMaxLength(255);

                entity.Property(e => e.AcceptedName)
                    .IsRequired()
                    .HasColumnName("accepted_name")
                    .HasMaxLength(510);

                entity.Property(e => e.ContractId)
                    .HasColumnName("contract_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HasAccepted)
                    .HasColumnName("has_accepted")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.SystemLoadDate)
                    .HasColumnName("system_load_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Waivers)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("FK_B364E1BE2576E0FD");
            });
        }
    }

    public class D1SoccerApiContextFactory : IDesignTimeDbContextFactory<D1SoccerApiContext> {
        public D1SoccerApiContext CreateDbContext(string[] args) {
            //var optionsBuilder = new DbContextOptionsBuilder<D1SoccerApiContext>();
            //optionsBuilder.UseSqlite("Data Source=blog.db");

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            return new D1SoccerApiContext(config);
        }
    }
}
