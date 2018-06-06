﻿// <auto-generated />
using D1SoccerService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace D1SoccerService.Migrations
{
    [DbContext(typeof(D1SoccerApiContext))]
    partial class D1SoccerServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("D1SoccerService.Entities.Announcements", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnName("content");

                    b.Property<DateTime>("SystemLoadDate")
                        .HasColumnName("system_load_date")
                        .HasColumnType("datetime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("announcements");
                });

            modelBuilder.Entity("D1SoccerService.Entities.CachedUsers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("CacheTime")
                        .HasColumnName("cache_time")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(255);

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnName("token")
                        .HasMaxLength(255);

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnName("uid")
                        .HasMaxLength(100);

                    b.Property<int?>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("Token")
                        .HasName("indx_token");

                    b.ToTable("cached_users");
                });

            modelBuilder.Entity("D1SoccerService.Entities.Contracts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<string>("ContractDisplayName")
                        .IsRequired()
                        .HasColumnName("contract_display_name")
                        .HasMaxLength(100);

                    b.Property<string>("ContractName")
                        .IsRequired()
                        .HasColumnName("contract_name")
                        .HasMaxLength(100);

                    b.Property<string>("ContractText")
                        .IsRequired()
                        .HasColumnName("contract_text");

                    b.Property<DateTime>("ContractValidEndDate")
                        .HasColumnName("contract_valid_end_date")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ContractValidStartDate")
                        .HasColumnName("contract_valid_start_date")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("SystemLoadDate")
                        .HasColumnName("system_load_date")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("contracts");
                });

            modelBuilder.Entity("D1SoccerService.Entities.ManualUserSeasons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<bool>("HasPaid")
                        .HasColumnName("has_paid")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("HasTeam")
                        .HasColumnName("has_team")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("HasWaiver")
                        .HasColumnName("has_waiver")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("PaymentId")
                        .HasColumnName("payment_id")
                        .HasColumnType("int(11)");

                    b.Property<int>("SeasonId")
                        .HasColumnName("season_id")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("SystemLoadDate")
                        .HasColumnName("system_load_date")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("SystemUpdateDate")
                        .HasColumnName("system_update_date")
                        .HasColumnType("datetime");

                    b.Property<int?>("TeamId")
                        .HasColumnName("team_id")
                        .HasColumnType("int(11)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("user_name")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("manual_user_seasons");
                });

            modelBuilder.Entity("D1SoccerService.Entities.Seasons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnName("end_date")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.Property<DateTime>("RegistrationEndDate")
                        .HasColumnName("registration_end_date")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("RegistrationStartDate")
                        .HasColumnName("registration_start_date")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("StartDate")
                        .HasColumnName("start_date")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("SystemLoadDate")
                        .HasColumnName("system_load_date")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("SystemUpdateDate")
                        .HasColumnName("system_update_date")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("seasons");
                });

            modelBuilder.Entity("D1SoccerService.Entities.Teams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<string>("CaptainFirstName")
                        .IsRequired()
                        .HasColumnName("captain_first_name")
                        .HasMaxLength(255);

                    b.Property<int>("CaptainId")
                        .HasColumnName("captain_id")
                        .HasColumnType("int(11)");

                    b.Property<string>("CaptainLastName")
                        .IsRequired()
                        .HasColumnName("captain_last_name")
                        .HasMaxLength(255);

                    b.Property<DateTime>("SystemLoadDate")
                        .HasColumnName("system_load_date")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("SystemUpdateDate")
                        .HasColumnName("system_update_date")
                        .HasColumnType("datetime");

                    b.Property<string>("TeamColor")
                        .IsRequired()
                        .HasColumnName("team_color")
                        .HasMaxLength(55);

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnName("team_name")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("teams");
                });

            modelBuilder.Entity("D1SoccerService.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("Dob")
                        .HasColumnName("dob")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(255);

                    b.Property<string>("EmergencyContact")
                        .IsRequired()
                        .HasColumnName("emergency_contact")
                        .HasMaxLength(255);

                    b.Property<string>("EmergencyContactPhone")
                        .IsRequired()
                        .HasColumnName("emergency_contact_phone")
                        .HasMaxLength(20);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasMaxLength(255);

                    b.Property<string>("Gender")
                        .HasColumnName("gender")
                        .HasMaxLength(20);

                    b.Property<bool>("IsDefense")
                        .HasColumnName("is_defense")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnName("is_email_verified")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsKeeper")
                        .HasColumnName("is_keeper")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsOffense")
                        .HasColumnName("is_offense")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasMaxLength(255);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("phone")
                        .HasMaxLength(20);

                    b.Property<string>("ShirtSize")
                        .HasColumnName("shirt_size")
                        .HasMaxLength(20);

                    b.Property<DateTime>("SystemLoadDate")
                        .HasColumnName("system_load_date")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("SystemUpdateDate")
                        .HasColumnName("system_update_date")
                        .HasColumnType("datetime");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnName("user_type")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .HasName("indx_email");

                    b.ToTable("users");
                });

            modelBuilder.Entity("D1SoccerService.Entities.UserSeasons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<bool>("HasPaid")
                        .HasColumnName("has_paid")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("HasTeam")
                        .HasColumnName("has_team")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("HasWaiver")
                        .HasColumnName("has_waiver")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("PaymentId")
                        .HasColumnName("payment_id")
                        .HasColumnType("int(11)");

                    b.Property<int>("SeasonId")
                        .HasColumnName("season_id")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("SystemLoadDate")
                        .HasColumnName("system_load_date")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("SystemUpdateDate")
                        .HasColumnName("system_update_date")
                        .HasColumnType("datetime");

                    b.Property<int?>("TeamId")
                        .HasColumnName("team_id")
                        .HasColumnType("int(11)");

                    b.Property<int?>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("int(11)");

                    b.Property<int?>("WaiverId")
                        .HasColumnName("waiver_id")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .HasName("IDX_E728F53EA76ED395");

                    b.HasIndex("WaiverId")
                        .IsUnique()
                        .HasName("UNIQ_E728F53EA43B7175");

                    b.ToTable("user_seasons");
                });

            modelBuilder.Entity("D1SoccerService.Entities.Waivers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("AcceptedDate")
                        .HasColumnName("accepted_date")
                        .HasColumnType("datetime");

                    b.Property<string>("AcceptedEmail")
                        .IsRequired()
                        .HasColumnName("accepted_email")
                        .HasMaxLength(255);

                    b.Property<string>("AcceptedIpaddress")
                        .IsRequired()
                        .HasColumnName("accepted_ipaddress")
                        .HasMaxLength(255);

                    b.Property<string>("AcceptedName")
                        .IsRequired()
                        .HasColumnName("accepted_name")
                        .HasMaxLength(510);

                    b.Property<int?>("ContractId")
                        .HasColumnName("contract_id")
                        .HasColumnType("int(11)");

                    b.Property<bool>("HasAccepted")
                        .HasColumnName("has_accepted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("SystemLoadDate")
                        .HasColumnName("system_load_date")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("ContractId")
                        .HasName("IDX_B364E1BE2576E0FD");

                    b.ToTable("waivers");
                });

            modelBuilder.Entity("D1SoccerService.Entities.UserSeasons", b =>
                {
                    b.HasOne("D1SoccerService.Entities.Users", "User")
                        .WithMany("UserSeasons")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_E728F53EA76ED395");

                    b.HasOne("D1SoccerService.Entities.Waivers", "Waiver")
                        .WithOne("UserSeason")
                        .HasForeignKey("D1SoccerService.Entities.UserSeasons", "WaiverId")
                        .HasConstraintName("FK_E728F53EA43B7175");
                });

            modelBuilder.Entity("D1SoccerService.Entities.Waivers", b =>
                {
                    b.HasOne("D1SoccerService.Entities.Contracts", "Contract")
                        .WithMany("Waivers")
                        .HasForeignKey("ContractId")
                        .HasConstraintName("FK_B364E1BE2576E0FD");
                });
#pragma warning restore 612, 618
        }
    }
}
