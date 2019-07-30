using Microsoft.EntityFrameworkCore.Migrations;

namespace TigerTaiwanTripWebService.Migrations
{
    public partial class AddTripName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TripName",
                table: "Tickets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TripName",
                table: "Tickets");
        }
    }
}
