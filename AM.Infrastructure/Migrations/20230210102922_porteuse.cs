using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    public partial class porteuse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationTickets",
                columns: table => new
                {
                    TicketFK = table.Column<int>(type: "int", nullable: false),
                    PassengerFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateReservation = table.Column<DateTime>(type: "date", nullable: false),
                    PassengerPassportNumber = table.Column<string>(type: "nvarchar(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationTickets", x => new { x.DateReservation, x.PassengerFK, x.TicketFK });
                    table.ForeignKey(
                        name: "FK_ReservationTickets_Passengers_PassengerPassportNumber",
                        column: x => x.PassengerPassportNumber,
                        principalTable: "Passengers",
                        principalColumn: "PassportNumber");
                    table.ForeignKey(
                        name: "FK_ReservationTickets_tickets_TicketFK",
                        column: x => x.TicketFK,
                        principalTable: "tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationTickets_PassengerPassportNumber",
                table: "ReservationTickets",
                column: "PassengerPassportNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationTickets_TicketFK",
                table: "ReservationTickets",
                column: "TicketFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationTickets");

            migrationBuilder.DropTable(
                name: "tickets");
        }
    }
}
