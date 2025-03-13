using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Weather.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedWeatherData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f9"));

            migrationBuilder.InsertData(
                table: "WeatherDatas",
                columns: new[] { "Id", "CityName", "LastUpdated", "Temperature", "WeatherCondition" },
                values: new object[,]
                {
                    { new Guid("0b3777aa-c28b-4d92-bd01-8cbe8fb7012e"), "Fort Worth", new DateTime(2025, 2, 27, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4801), 31.5m, "Sunny" },
                    { new Guid("0d1adbdc-4600-40fe-a373-d66daa80bf1f"), "Seattle", new DateTime(2025, 2, 22, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4814), 21.9m, "Cloudy" },
                    { new Guid("34cfb2af-2a58-4df1-87d8-b0872c0c8e45"), "Phoenix", new DateTime(2025, 3, 7, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4775), 35.6m, "Sunny" },
                    { new Guid("3d74a7d0-2135-4195-9a34-cd19d762a368"), "Austin", new DateTime(2025, 3, 1, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4793), 28.5m, "Stormy" },
                    { new Guid("4e47731b-11df-474b-8986-95b35a28c0ad"), "Charlotte", new DateTime(2025, 2, 25, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4806), 25.1m, "Windy" },
                    { new Guid("4effe177-9e93-4bec-8e5e-394db5b80bc0"), "Los Angeles", new DateTime(2025, 3, 10, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4757), 27.8m, "Cloudy" },
                    { new Guid("5d2f42f8-d3eb-4156-8e16-ccb45e0ab9d0"), "Nashville", new DateTime(2025, 2, 17, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4829), 22.9m, "Cloudy" },
                    { new Guid("6091f815-d8ac-4fa3-94bd-f7aa650b3c70"), "Philadelphia", new DateTime(2025, 3, 6, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4780), 18.9m, "Windy" },
                    { new Guid("6cbbc716-a77a-4cf1-9dd5-f153a9cab368"), "Chicago", new DateTime(2025, 3, 9, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4760), 15.2m, "Rainy" },
                    { new Guid("7212fc4b-b23a-4b6d-b44e-c85bd4a090a8"), "El Paso", new DateTime(2025, 2, 18, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4826), 27.6m, "Sunny" },
                    { new Guid("823f98d8-57b4-4306-a4fc-36d7e042cbb7"), "Jacksonville", new DateTime(2025, 2, 28, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4796), 22.0m, "Rainy" },
                    { new Guid("88449bae-d056-46f4-84c6-d0adf629181d"), "Indianapolis", new DateTime(2025, 2, 23, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4810), 17.4m, "Rainy" },
                    { new Guid("8f4f259d-93c0-43ac-933c-adb33519da2a"), "San Antonio", new DateTime(2025, 3, 5, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4783), 29.3m, "Rainy" },
                    { new Guid("9db68759-ec29-409c-a74e-d9064b459c9b"), "Boston", new DateTime(2025, 2, 19, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4824), 14.2m, "Rainy" },
                    { new Guid("a8dac547-f799-4787-b394-676d986f5808"), "San Diego", new DateTime(2025, 3, 4, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4785), 24.5m, "Foggy" },
                    { new Guid("c2034ec1-1bba-40da-a9b8-6636f3804a56"), "Detroit", new DateTime(2025, 2, 16, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4831), 19.1m, "Foggy" },
                    { new Guid("c3c7b42d-84e5-4b7b-87e6-86d61170620d"), "San Jose", new DateTime(2025, 3, 2, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4791), 26.4m, "Cloudy" },
                    { new Guid("c775cdd5-904e-4d54-ace5-f3232b0a28e7"), "Dallas", new DateTime(2025, 3, 3, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4787), 32.2m, "Sunny" },
                    { new Guid("cd7913c0-0250-4a1c-923d-12e081f5cbde"), "New York", new DateTime(2025, 3, 11, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4726), 23.5m, "Sunny" },
                    { new Guid("e3ac7f2c-0ea3-49cd-b013-e7b538b4eb63"), "Columbus", new DateTime(2025, 2, 26, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4803), 20.3m, "Cloudy" },
                    { new Guid("e3dfc7ae-2c7e-434d-a036-e7c1c7d39e85"), "Denver", new DateTime(2025, 2, 21, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4817), 16.3m, "Sunny" },
                    { new Guid("e9159122-fcb8-4d09-9a31-681b7714dd5f"), "San Francisco", new DateTime(2025, 2, 24, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4808), 19.8m, "Foggy" },
                    { new Guid("f771d133-2812-4e9d-a587-f65085f3f599"), "Oklahoma City", new DateTime(2025, 2, 15, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4833), 30.0m, "Sunny" },
                    { new Guid("fbcff8e9-42d4-4073-9ae3-4226ad161efb"), "Washington", new DateTime(2025, 2, 20, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4819), 20.7m, "Windy" },
                    { new Guid("fc8839a8-c22f-4f17-ba6f-7c7b9d0dd420"), "Houston", new DateTime(2025, 3, 8, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4763), 30.1m, "Sunny" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("0b3777aa-c28b-4d92-bd01-8cbe8fb7012e"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("0d1adbdc-4600-40fe-a373-d66daa80bf1f"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("34cfb2af-2a58-4df1-87d8-b0872c0c8e45"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("3d74a7d0-2135-4195-9a34-cd19d762a368"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("4e47731b-11df-474b-8986-95b35a28c0ad"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("4effe177-9e93-4bec-8e5e-394db5b80bc0"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("5d2f42f8-d3eb-4156-8e16-ccb45e0ab9d0"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("6091f815-d8ac-4fa3-94bd-f7aa650b3c70"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("6cbbc716-a77a-4cf1-9dd5-f153a9cab368"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("7212fc4b-b23a-4b6d-b44e-c85bd4a090a8"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("823f98d8-57b4-4306-a4fc-36d7e042cbb7"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("88449bae-d056-46f4-84c6-d0adf629181d"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("8f4f259d-93c0-43ac-933c-adb33519da2a"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("9db68759-ec29-409c-a74e-d9064b459c9b"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("a8dac547-f799-4787-b394-676d986f5808"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("c2034ec1-1bba-40da-a9b8-6636f3804a56"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("c3c7b42d-84e5-4b7b-87e6-86d61170620d"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("c775cdd5-904e-4d54-ace5-f3232b0a28e7"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("cd7913c0-0250-4a1c-923d-12e081f5cbde"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("e3ac7f2c-0ea3-49cd-b013-e7b538b4eb63"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("e3dfc7ae-2c7e-434d-a036-e7c1c7d39e85"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("e9159122-fcb8-4d09-9a31-681b7714dd5f"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("f771d133-2812-4e9d-a587-f65085f3f599"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("fbcff8e9-42d4-4073-9ae3-4226ad161efb"));

            migrationBuilder.DeleteData(
                table: "WeatherDatas",
                keyColumn: "Id",
                keyValue: new Guid("fc8839a8-c22f-4f17-ba6f-7c7b9d0dd420"));

            migrationBuilder.InsertData(
                table: "WeatherDatas",
                columns: new[] { "Id", "CityName", "LastUpdated", "Temperature", "WeatherCondition" },
                values: new object[,]
                {
                    { new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "Delhi", new DateTime(2025, 3, 12, 22, 46, 55, 591, DateTimeKind.Local).AddTicks(25), 30m, "Sunny" },
                    { new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f9"), "Bhubaneswar", new DateTime(2025, 3, 12, 22, 46, 55, 591, DateTimeKind.Local).AddTicks(46), 55m, "Sunny" }
                });
        }
    }
}
