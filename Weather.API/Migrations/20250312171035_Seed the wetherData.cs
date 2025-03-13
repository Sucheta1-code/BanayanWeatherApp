using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Weather.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedthewetherData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WeatherDatas",
                columns: new[] { "Id", "CityName", "LastUpdated", "Temperature", "WeatherCondition" },
                values: new object[,]
                {
                    { new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "Delhi", new DateTime(2025, 3, 12, 22, 40, 35, 502, DateTimeKind.Local).AddTicks(1427), 30m, "Sunny" },
                    { new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f9"), "Bhubaneswar", new DateTime(2025, 3, 12, 22, 40, 35, 502, DateTimeKind.Local).AddTicks(1456), 55m, "Sunny" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f9"));
        }
    }
}
