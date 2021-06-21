using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightManagement.Migrations
{
    public partial class updateflightnumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightID",
                keyValue: 1,
                columns: new[] { "EndTime", "FlightNumber", "StartTime" },
                values: new object[] { "183758", "VN117", "170758" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightID",
                keyValue: 2,
                columns: new[] { "EndTime", "FlightNumber", "StartTime" },
                values: new object[] { "193758", "VN399", "170758" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightID",
                keyValue: 1,
                columns: new[] { "EndTime", "FlightNumber", "StartTime" },
                values: new object[] { "183422", null, "170422" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightID",
                keyValue: 2,
                columns: new[] { "EndTime", "FlightNumber", "StartTime" },
                values: new object[] { "193422", null, "170422" });
        }
    }
}
