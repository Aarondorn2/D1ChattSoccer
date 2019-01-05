using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace D1SoccerApi.Migrations
{
    public partial class Credentials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credential",
                columns: table => new
                {
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Password = table.Column<string>(maxLength: 255, nullable: false),
                    LastLogin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credential", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "FailedLogin",
                columns: table => new
                {
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Attempt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FailedLogin", x => x.Email);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credential");

            migrationBuilder.DropTable(
                name: "FailedLogin");

            migrationBuilder.DropIndex(
                name: "IX_User_Email",
                table: "User");
        }
    }
}
