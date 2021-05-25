using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AODMS.Migrations
{
    public partial class DailyLogSummaryDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "DailyLogSummaries",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "DailyLogSummaries",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
