using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservation.Data.Migrations
{
    public partial class UpdateMg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Reservation",
                columns: table => new
                {
                    ReservationId = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Activities = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    DateTravel = table.Column<string>(nullable: true),
                    HotelRooms = table.Column<string>(nullable: true),
                    DateRegistered = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Reservation", x => x.ReservationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Reservation");
        }
    }
}
