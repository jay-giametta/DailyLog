using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AODMS.Migrations
{
    public partial class DbBuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyLogEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LogSummaryId = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(nullable: false),
                    Entry = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyLogEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyLogLocations",
                columns: table => new
                {
                    Unit = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyLogLocations", x => x.Unit);
                });

            migrationBuilder.CreateTable(
                name: "DailyLogSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Unit = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CertifiedBy = table.Column<string>(nullable: true),
                    ValidatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyLogSummaries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyLogEntries");

            migrationBuilder.DropTable(
                name: "DailyLogLocations");

            migrationBuilder.DropTable(
                name: "DailyLogSummaries");
        }
    }
}
