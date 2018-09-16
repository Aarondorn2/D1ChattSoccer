using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace D1SoccerApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ContractName = table.Column<string>(maxLength: 255, nullable: false),
                    ContractDisplayName = table.Column<string>(maxLength: 255, nullable: false),
                    ContractText = table.Column<string>(nullable: false),
                    ContractValidStartDate = table.Column<DateTime>(nullable: false),
                    ContractValidEndDate = table.Column<DateTime>(nullable: true),
                    SystemLoadDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    RegistrationStartDate = table.Column<DateTime>(nullable: false),
                    RegistrationEndDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    SystemLoadDate = table.Column<DateTime>(nullable: false),
                    SystemUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Info",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Phone = table.Column<string>(maxLength: 55, nullable: true),
                    EmergencyContact = table.Column<string>(maxLength: 255, nullable: true),
                    EmergencyContactPhone = table.Column<string>(maxLength: 55, nullable: true),
                    Dob = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(maxLength: 25, nullable: true),
                    ShirtSize = table.Column<string>(maxLength: 25, nullable: true),
                    IsDefense = table.Column<bool>(nullable: false),
                    IsKeeper = table.Column<bool>(nullable: false),
                    IsOffense = table.Column<bool>(nullable: false),
                    SystemLoadDate = table.Column<DateTime>(nullable: false),
                    SystemUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    LastName = table.Column<string>(maxLength: 255, nullable: false),
                    UserType = table.Column<byte>(nullable: false),
                    IsEmailVerified = table.Column<bool>(nullable: false),
                    UserInfoId = table.Column<int>(nullable: true),
                    SystemLoadDate = table.Column<DateTime>(nullable: false),
                    SystemUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_User_Info_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "User_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TeamName = table.Column<string>(maxLength: 255, nullable: false),
                    TeamColor = table.Column<string>(maxLength: 50, nullable: false),
                    CaptainUserId = table.Column<int>(nullable: true),
                    SeasonId = table.Column<int>(nullable: false),
                    SystemLoadDate = table.Column<DateTime>(nullable: false),
                    SystemUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_User_CaptainUserId",
                        column: x => x.CaptainUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Team_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manual_User_Season",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 255, nullable: false),
                    HasPaid = table.Column<bool>(nullable: false),
                    HasWaiver = table.Column<bool>(nullable: false),
                    SeasonId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: true),
                    SystemLoadDate = table.Column<DateTime>(nullable: false),
                    SystemUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manual_User_Season", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manual_User_Season_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manual_User_Season_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Waiver",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AcceptedName = table.Column<string>(maxLength: 255, nullable: false),
                    AcceptedEmail = table.Column<string>(maxLength: 255, nullable: false),
                    AcceptedIpaddress = table.Column<string>(maxLength: 255, nullable: false),
                    HasAccepted = table.Column<bool>(nullable: false),
                    UserSeasonId = table.Column<int>(nullable: false),
                    ContractId = table.Column<int>(nullable: false),
                    AcceptedDate = table.Column<DateTime>(nullable: false),
                    SystemLoadDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waiver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Waiver_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Season",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    SeasonId = table.Column<int>(nullable: false),
                    HasPaid = table.Column<bool>(nullable: false),
                    TeamId = table.Column<int>(nullable: true),
                    WaiverId = table.Column<int>(nullable: true),
                    SystemLoadDate = table.Column<DateTime>(nullable: false),
                    SystemUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Season", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Season_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Season_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Season_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Season_Waiver_WaiverId",
                        column: x => x.WaiverId,
                        principalTable: "Waiver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manual_User_Season_SeasonId",
                table: "Manual_User_Season",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Manual_User_Season_TeamId",
                table: "Manual_User_Season",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_CaptainUserId",
                table: "Team",
                column: "CaptainUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_SeasonId",
                table: "Team",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserInfoId",
                table: "User",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Season_SeasonId",
                table: "User_Season",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Season_TeamId",
                table: "User_Season",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Season_UserId",
                table: "User_Season",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Season_WaiverId",
                table: "User_Season",
                column: "WaiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Waiver_ContractId",
                table: "Waiver",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Waiver_UserSeasonId",
                table: "Waiver",
                column: "UserSeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Waiver_User_Season_UserSeasonId",
                table: "Waiver",
                column: "UserSeasonId",
                principalTable: "User_Season",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_Season_SeasonId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Season_Season_SeasonId",
                table: "User_Season");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Season_Team_TeamId",
                table: "User_Season");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Season_User_UserId",
                table: "User_Season");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Season_Waiver_WaiverId",
                table: "User_Season");

            migrationBuilder.DropTable(
                name: "Manual_User_Season");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "User_Info");

            migrationBuilder.DropTable(
                name: "Waiver");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "User_Season");
        }
    }
}
