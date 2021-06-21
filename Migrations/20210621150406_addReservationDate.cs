using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightManagement.Migrations
{
    public partial class addReservationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReservationDate",
                table: "Bookings",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightID",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { "233406", "220406" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightID",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { "003406", "220406" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationDate",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightID",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { "183758", "170758" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightID",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { "193758", "170758" });
        }
    }
}
