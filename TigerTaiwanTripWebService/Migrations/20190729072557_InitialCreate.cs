using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TigerTaiwanTripWebService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    MobilePhone = table.Column<string>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PassWord = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketID = table.Column<Guid>(nullable: false),
                    PaymentExpireDay = table.Column<DateTime>(nullable: false),
                    TravelStrateDate = table.Column<DateTime>(nullable: false),
                    Payed = table.Column<bool>(nullable: false),
                    PaymentMethodUsed = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    TicketType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketID);
                });

            migrationBuilder.CreateTable(
                name: "MemberTickets",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(nullable: false),
                    TicketId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTickets", x => new { x.MemberId, x.TicketId });
                    table.ForeignKey(
                        name: "FK_MemberTickets_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberTickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberTickets_TicketId",
                table: "MemberTickets",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberTickets");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
