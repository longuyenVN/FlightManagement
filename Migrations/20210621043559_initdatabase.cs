using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightManagement.Migrations
{
    public partial class initdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartTime = table.Column<string>(type: "TEXT", nullable: true),
                    EndTime = table.Column<string>(type: "TEXT", nullable: true),
                    PassengerCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    DeparterCity = table.Column<string>(type: "TEXT", nullable: true),
                    ArrivalCity = table.Column<string>(type: "TEXT", nullable: true),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightID);
                });

            migrationBuilder.CreateTable(
                name: "FlightNumbers",
                columns: table => new
                {
                    FlightNumberID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FlightID = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<string>(type: "TEXT", nullable: true),
                    NoOfPax = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightNumbers", x => x.FlightNumberID);
                    table.ForeignKey(
                        name: "FK_FlightNumbers_Flights_FlightID",
                        column: x => x.FlightID,
                        principalTable: "Flights",
                        principalColumn: "FlightID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PassengerName = table.Column<string>(type: "TEXT", nullable: true),
                    PassengerCID = table.Column<int>(type: "INTEGER", nullable: false),
                    FlightID = table.Column<int>(type: "INTEGER", nullable: false),
                    NoOfPax = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FlightNumberID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Bookings_FlightNumbers_FlightNumberID",
                        column: x => x.FlightNumberID,
                        principalTable: "FlightNumbers",
                        principalColumn: "FlightNumberID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightID", "ArrivalCity", "DeparterCity", "EndTime", "IsAvailable", "PassengerCapacity", "StartTime" },
                values: new object[] { 1, "Tp.Hochiminh", "Danang", "130559", true, 10, "113559" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightID", "ArrivalCity", "DeparterCity", "EndTime", "IsAvailable", "PassengerCapacity", "StartTime" },
                values: new object[] { 2, "Phuquoc", "Danang", "140559", true, 5, "113559" });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FlightNumberID",
                table: "Bookings",
                column: "FlightNumberID");

            migrationBuilder.CreateIndex(
                name: "IX_FlightNumbers_FlightID",
                table: "FlightNumbers",
                column: "FlightID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "FlightNumbers");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
