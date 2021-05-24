using Microsoft.EntityFrameworkCore.Migrations;

namespace AODMS.Migrations
{
    public partial class CertifiedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CertifiedBy",
                table: "DailyLogSummaries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CertifiedBy",
                table: "DailyLogSummaries");
        }
    }
}
