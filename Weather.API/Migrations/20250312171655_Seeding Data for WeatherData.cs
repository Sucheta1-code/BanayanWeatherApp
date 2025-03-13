using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weather.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforWeatherData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                column: "LastUpdated",
                value: new DateTime(2025, 3, 12, 22, 46, 55, 591, DateTimeKind.Local).AddTicks(25));

            migrationBuilder.UpdateData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f9"),
                column: "LastUpdated",
                value: new DateTime(2025, 3, 12, 22, 46, 55, 591, DateTimeKind.Local).AddTicks(46));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                column: "LastUpdated",
                value: new DateTime(2025, 3, 12, 22, 40, 35, 502, DateTimeKind.Local).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f9"),
                column: "LastUpdated",
                value: new DateTime(2025, 3, 12, 22, 40, 35, 502, DateTimeKind.Local).AddTicks(1456));
        }
    }
}
