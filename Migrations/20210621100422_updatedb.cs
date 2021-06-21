using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightManagement.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_FlightNumbers_FlightNumberID",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "FlightNumbers");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_FlightNumberID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "FlightNumberID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PassengerCID",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "FlightNumber",
                table: "Flights",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightID",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { "183422", "170422" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightID",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { "193422", "170422" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightNumber",
                table: "Flights");

            migrationBuilder.AddColumn<int>(
                name: "FlightNumberID",
                table: "Bookings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PassengerCID",
                table: "Bookings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FlightNumbers",
                columns: table => new
                {
                    FlightNumberID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<string>(type: "TEXT", nullable: true),
                    FlightID = table.Column<int>(type: "INTEGER", nullable: false),
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

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightID",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { "130559", "113559" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightID",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { "140559", "113559" });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FlightNumberID",
                table: "Bookings",
                column: "FlightNumberID");

            migrationBuilder.CreateIndex(
                name: "IX_FlightNumbers_FlightID",
                table: "FlightNumbers",
                column: "FlightID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_FlightNumbers_FlightNumberID",
                table: "Bookings",
                column: "FlightNumberID",
                principalTable: "FlightNumbers",
                principalColumn: "FlightNumberID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
