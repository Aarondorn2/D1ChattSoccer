using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace D1SoccerService.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "cachedusers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cache_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    email = table.Column<string>(maxLength: 255, nullable: false),
                    token = table.Column<string>(maxLength: 255, nullable: false),
                    uid = table.Column<string>(maxLength: 100, nullable: false),
                    user_id = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cachedusers", x => x.id);
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
                name: "manualuserseasons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    has_paid = table.Column<sbyte>(type: "tinyint(1)", nullable: false),
                    has_team = table.Column<sbyte>(type: "tinyint(1)", nullable: false),
                    has_waiver = table.Column<sbyte>(type: "tinyint(1)", nullable: false),
                    is_manual = table.Column<sbyte>(type: "tinyint(1)", nullable: false),
                    payment_id = table.Column<int>(type: "int(11)", nullable: true),
                    season_id = table.Column<int>(type: "int(11)", nullable: false),
                    system_load_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    system_update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    team_id = table.Column<int>(type: "int(11)", nullable: true),
                    user_name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manualuserseasons", x => x.id);
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
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dob = table.Column<DateTime>(type: "datetime", nullable: false),
                    email = table.Column<string>(maxLength: 255, nullable: false),
                    emergency_contact = table.Column<string>(maxLength: 255, nullable: false),
                    emergency_contact_phone = table.Column<string>(maxLength: 20, nullable: false),
                    first_name = table.Column<string>(maxLength: 255, nullable: false),
                    gender = table.Column<string>(maxLength: 20, nullable: true),
                    is_defense = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_keeper = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_offense = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    last_name = table.Column<string>(maxLength: 255, nullable: false),
                    phone = table.Column<string>(maxLength: 20, nullable: false),
                    shirt_size = table.Column<string>(maxLength: 20, nullable: true),
                    system_load_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    system_update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    user_type = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
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

            migrationBuilder.CreateTable(
                name: "userseasons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    has_paid = table.Column<sbyte>(type: "tinyint(1)", nullable: false),
                    has_team = table.Column<sbyte>(type: "tinyint(1)", nullable: false),
                    has_waiver = table.Column<sbyte>(type: "tinyint(1)", nullable: false),
                    is_manual = table.Column<sbyte>(type: "tinyint(1)", nullable: false),
                    payment_id = table.Column<int>(type: "int(11)", nullable: true),
                    season_id = table.Column<int>(type: "int(11)", nullable: false),
                    system_load_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    system_update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    team_id = table.Column<int>(type: "int(11)", nullable: true),
                    user_id = table.Column<int>(type: "int(11)", nullable: true),
                    waiver_id = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userseasons", x => x.id);
                    table.ForeignKey(
                        name: "FK_E728F53EA76ED395",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_E728F53EA43B7175",
                        column: x => x.waiver_id,
                        principalTable: "waiver",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "indx_token",
                table: "cachedusers",
                column: "token");

            migrationBuilder.CreateIndex(
                name: "indx_email",
                table: "users",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "IDX_E728F53EA76ED395",
                table: "userseasons",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UNIQ_E728F53EA43B7175",
                table: "userseasons",
                column: "waiver_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_B364E1BE2576E0FD",
                table: "waiver",
                column: "contract_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "announcement");

            migrationBuilder.DropTable(
                name: "cachedusers");

            migrationBuilder.DropTable(
                name: "manualuserseasons");

            migrationBuilder.DropTable(
                name: "season");

            migrationBuilder.DropTable(
                name: "team");

            migrationBuilder.DropTable(
                name: "userseasons");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "waiver");

            migrationBuilder.DropTable(
                name: "contract");
        }
    }
}
