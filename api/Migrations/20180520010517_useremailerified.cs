using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace D1SoccerService.Migrations
{
    public partial class useremailerified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_E728F53EA43B7175",
                table: "userseasons");

            migrationBuilder.DropTable(
                name: "announcement");

            migrationBuilder.DropTable(
                name: "season");

            migrationBuilder.DropTable(
                name: "team");

            migrationBuilder.DropTable(
                name: "waiver");

            migrationBuilder.DropTable(
                name: "contract");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userseasons",
                table: "userseasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_manualuserseasons",
                table: "manualuserseasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cachedusers",
                table: "cachedusers");

            migrationBuilder.DropColumn(
                name: "is_manual",
                table: "userseasons");

            migrationBuilder.DropColumn(
                name: "is_manual",
                table: "manualuserseasons");

            migrationBuilder.RenameTable(
                name: "userseasons",
                newName: "user_seasons");

            migrationBuilder.RenameTable(
                name: "manualuserseasons",
                newName: "manual_user_seasons");

            migrationBuilder.RenameTable(
                name: "cachedusers",
                newName: "cached_users");

            migrationBuilder.AddColumn<bool>(
                name: "is_email_verified",
                table: "users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_seasons",
                table: "user_seasons",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_manual_user_seasons",
                table: "manual_user_seasons",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cached_users",
                table: "cached_users",
                column: "id");

            migrationBuilder.CreateTable(
                name: "announcements",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    content = table.Column<string>(nullable: false),
                    system_load_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    title = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_announcements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contracts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    contract_display_name = table.Column<string>(maxLength: 100, nullable: false),
                    contract_name = table.Column<string>(maxLength: 100, nullable: false),
                    contract_text = table.Column<string>(nullable: false),
                    contract_valid_end_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    contract_valid_start_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    system_load_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contracts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "seasons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    end_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    registration_end_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    registration_start_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    system_load_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    system_update_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seasons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    captain_first_name = table.Column<string>(maxLength: 255, nullable: false),
                    captain_id = table.Column<int>(type: "int(11)", nullable: false),
                    captain_last_name = table.Column<string>(maxLength: 255, nullable: false),
                    system_load_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    system_update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    team_color = table.Column<string>(maxLength: 55, nullable: false),
                    team_name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "waivers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    accepted_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    accepted_email = table.Column<string>(maxLength: 255, nullable: false),
                    accepted_ipaddress = table.Column<string>(maxLength: 255, nullable: false),
                    accepted_name = table.Column<string>(maxLength: 510, nullable: false),
                    contract_id = table.Column<int>(type: "int(11)", nullable: true),
                    has_accepted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    system_load_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_waivers", x => x.id);
                    table.ForeignKey(
                        name: "FK_B364E1BE2576E0FD",
                        column: x => x.contract_id,
                        principalTable: "contracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_B364E1BE2576E0FD",
                table: "waivers",
                column: "contract_id");

            migrationBuilder.AddForeignKey(
                name: "FK_E728F53EA43B7175",
                table: "user_seasons",
                column: "waiver_id",
                principalTable: "waivers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_E728F53EA43B7175",
                table: "user_seasons");

            migrationBuilder.DropTable(
                name: "announcements");

            migrationBuilder.DropTable(
                name: "seasons");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropTable(
                name: "waivers");

            migrationBuilder.DropTable(
                name: "contracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_seasons",
                table: "user_seasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_manual_user_seasons",
                table: "manual_user_seasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cached_users",
                table: "cached_users");

            migrationBuilder.DropColumn(
                name: "is_email_verified",
                table: "users");

            migrationBuilder.RenameTable(
                name: "user_seasons",
                newName: "userseasons");

            migrationBuilder.RenameTable(
                name: "manual_user_seasons",
                newName: "manualuserseasons");

            migrationBuilder.RenameTable(
                name: "cached_users",
                newName: "cachedusers");

            migrationBuilder.AddColumn<sbyte>(
                name: "is_manual",
                table: "userseasons",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: (sbyte)0);

            migrationBuilder.AddColumn<sbyte>(
                name: "is_manual",
                table: "manualuserseasons",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: (sbyte)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_userseasons",
                table: "userseasons",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_manualuserseasons",
                table: "manualuserseasons",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cachedusers",
                table: "cachedusers",
                column: "id");

            migrationBuilder.CreateTable(
                name: "announcement",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    content = table.Column<string>(nullable: false),
                    system_load_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    title = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_announcement", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contract",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    contract_display_name = table.Column<string>(maxLength: 100, nullable: false),
                    contract_name = table.Column<string>(maxLength: 100, nullable: false),
                    contract_text = table.Column<string>(nullable: false),
                    contract_valid_end_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    contract_valid_start_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    system_load_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contract", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "season",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    end_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    registration_end_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    registration_start_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    system_load_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    system_update_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_season", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "team",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    captain_first_name = table.Column<string>(maxLength: 255, nullable: false),
                    captain_id = table.Column<int>(type: "int(11)", nullable: false),
                    captain_last_name = table.Column<string>(maxLength: 255, nullable: false),
                    system_load_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    system_update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    team_color = table.Column<string>(maxLength: 55, nullable: false),
                    team_name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "waiver",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    accepted_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    accepted_email = table.Column<string>(maxLength: 255, nullable: false),
                    accepted_ipaddress = table.Column<string>(maxLength: 255, nullable: false),
                    accepted_name = table.Column<string>(maxLength: 510, nullable: false),
                    contract_id = table.Column<int>(type: "int(11)", nullable: true),
                    has_accepted = table.Column<sbyte>(type: "tinyint(1)", nullable: false),
                    system_load_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_waiver", x => x.id);
                    table.ForeignKey(
                        name: "FK_B364E1BE2576E0FD",
                        column: x => x.contract_id,
                        principalTable: "contract",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_B364E1BE2576E0FD",
                table: "waiver",
                column: "contract_id");

            migrationBuilder.AddForeignKey(
                name: "FK_E728F53EA43B7175",
                table: "userseasons",
                column: "waiver_id",
                principalTable: "waiver",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
