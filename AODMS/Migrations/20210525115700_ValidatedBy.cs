using Microsoft.EntityFrameworkCore.Migrations;

namespace AODMS.Migrations
{
    public partial class ValidatedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ValidatedBy",
                table: "DailyLogSummaries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidatedBy",
                table: "DailyLogSummaries");
        }
    }
}
