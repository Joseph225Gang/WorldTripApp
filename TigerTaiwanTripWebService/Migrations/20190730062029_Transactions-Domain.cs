using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TigerTaiwanTripWebService.Migrations
{
    public partial class TransactionsDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Payed",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PaymentMethodUsed",
                table: "Tickets");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MemberName = table.Column<string>(nullable: true),
                    PaymentMethod = table.Column<int>(nullable: false),
                    TripName = table.Column<string>(nullable: true),
                    AdultTicket = table.Column<int>(nullable: false),
                    ChildTicket = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.AddColumn<bool>(
                name: "Payed",
                table: "Tickets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodUsed",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);
        }
    }
}
