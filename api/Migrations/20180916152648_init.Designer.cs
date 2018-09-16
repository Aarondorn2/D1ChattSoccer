﻿// <auto-generated />
using D1SoccerApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace D1SoccerApi.Migrations
{
    [DbContext(typeof(D1SoccerApiContext))]
    [Migration("20180916152648_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("D1SoccerApi.Entities.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContractDisplayName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("ContractName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("ContractText")
                        .IsRequired();

                    b.Property<DateTime?>("ContractValidEndDate");

                    b.Property<DateTime>("ContractValidStartDate");

                    b.Property<DateTime>("SystemLoadDate");

                    b.HasKey("Id");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("D1SoccerApi.Entities.ManualUserSeason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("HasPaid");

                    b.Property<bool>("HasWaiver");

                    b.Property<int>("SeasonId");

                    b.Property<DateTime>("SystemLoadDate");

                    b.Property<DateTime>("SystemUpdateDate");

                    b.Property<int?>("TeamId");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("SeasonId");

                    b.HasIndex("TeamId");

                    b.ToTable("Manual_User_Season");
                });

            modelBuilder.Entity("D1SoccerApi.Entities.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("RegistrationEndDate");

                    b.Property<DateTime>("RegistrationStartDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<DateTime>("SystemLoadDate");

                    b.Property<DateTime>("SystemUpdateDate");

                    b.HasKey("Id");

                    b.ToTable("Season");
                });

            modelBuilder.Entity("D1SoccerApi.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CaptainUserId");

                    b.Property<int>("SeasonId");

                    b.Property<DateTime>("SystemLoadDate");

                    b.Property<DateTime>("SystemUpdateDate");

                    b.Property<string>("TeamColor")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CaptainUserId");

                    b.HasIndex("SeasonId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("D1SoccerApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("IsEmailVerified");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("SystemLoadDate");

                    b.Property<DateTime>("SystemUpdateDate");

                    b.Property<int?>("UserInfoId");

                    b.Property<byte>("UserType");

                    b.HasKey("Id");

                    b.HasIndex("UserInfoId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("D1SoccerApi.Entities.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Dob");

                    b.Property<string>("EmergencyContact")
                        .HasMaxLength(255);

                    b.Property<string>("EmergencyContactPhone")
                        .HasMaxLength(55);

                    b.Property<string>("Gender")
                        .HasMaxLength(25);

                    b.Property<bool>("IsDefense");

                    b.Property<bool>("IsKeeper");

                    b.Property<bool>("IsOffense");

                    b.Property<string>("Phone")
                        .HasMaxLength(55);

                    b.Property<string>("ShirtSize")
                        .HasMaxLength(25);

                    b.Property<DateTime>("SystemLoadDate");

                    b.Property<DateTime>("SystemUpdateDate");

                    b.HasKey("Id");

                    b.ToTable("User_Info");
                });

            modelBuilder.Entity("D1SoccerApi.Entities.UserSeason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("HasPaid");

                    b.Property<int>("SeasonId");

                    b.Property<DateTime>("SystemLoadDate");

                    b.Property<DateTime>("SystemUpdateDate");

                    b.Property<int?>("TeamId");

                    b.Property<int>("UserId");

                    b.Property<int?>("WaiverId");

                    b.HasKey("Id");

                    b.HasIndex("SeasonId");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.HasIndex("WaiverId");

                    b.ToTable("User_Season");
                });

            modelBuilder.Entity("D1SoccerApi.Entities.Waiver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AcceptedDate");

                    b.Property<string>("AcceptedEmail")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("AcceptedIpaddress")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("AcceptedName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("ContractId");

                    b.Property<bool>("HasAccepted");

                    b.Property<DateTime>("SystemLoadDate");

                    b.Property<int>("UserSeasonId");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("UserSeasonId");

                    b.ToTable("Waiver");
                });

            modelBuilder.Entity("D1SoccerApi.Entities.ManualUserSeason", b =>
                {
                    b.HasOne("D1SoccerApi.Entities.Season", "Season")
                        .WithMany("ManualUserSeasons")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("D1SoccerApi.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("D1SoccerApi.Entities.Team", b =>
                {
                    b.HasOne("D1SoccerApi.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("CaptainUserId");

                    b.HasOne("D1SoccerApi.Entities.Season", "Season")
                        .WithMany("Teams")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("D1SoccerApi.Entities.User", b =>
                {
                    b.HasOne("D1SoccerApi.Entities.UserInfo", "UserInfo")
                        .WithMany()
                        .HasForeignKey("UserInfoId");
                });

            modelBuilder.Entity("D1SoccerApi.Entities.UserSeason", b =>
                {
                    b.HasOne("D1SoccerApi.Entities.Season", "Season")
                        .WithMany("UserSeasons")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("D1SoccerApi.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.HasOne("D1SoccerApi.Entities.User", "User")
                        .WithMany("UserSeasons")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("D1SoccerApi.Entities.Waiver", "Waiver")
                        .WithMany()
                        .HasForeignKey("WaiverId");
                });

            modelBuilder.Entity("D1SoccerApi.Entities.Waiver", b =>
                {
                    b.HasOne("D1SoccerApi.Entities.Contract")
                        .WithMany("Waivers")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("D1SoccerApi.Entities.UserSeason", "UserSeason")
                        .WithMany()
                        .HasForeignKey("UserSeasonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}