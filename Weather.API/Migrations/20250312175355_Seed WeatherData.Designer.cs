﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Weather.API.Data;

#nullable disable

namespace Weather.API.Migrations
{
    [DbContext(typeof(WeatherDataDbContext))]
    [Migration("20250312175355_Seed WeatherData")]
    partial class SeedWeatherData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Weather.API.Models.Domain.WeatherData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Temperature")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("WeatherCondition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WeatherDatas");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cd7913c0-0250-4a1c-923d-12e081f5cbde"),
                            CityName = "New York",
                            LastUpdated = new DateTime(2025, 3, 11, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4726),
                            Temperature = 23.5m,
                            WeatherCondition = "Sunny"
                        },
                        new
                        {
                            Id = new Guid("4effe177-9e93-4bec-8e5e-394db5b80bc0"),
                            CityName = "Los Angeles",
                            LastUpdated = new DateTime(2025, 3, 10, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4757),
                            Temperature = 27.8m,
                            WeatherCondition = "Cloudy"
                        },
                        new
                        {
                            Id = new Guid("6cbbc716-a77a-4cf1-9dd5-f153a9cab368"),
                            CityName = "Chicago",
                            LastUpdated = new DateTime(2025, 3, 9, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4760),
                            Temperature = 15.2m,
                            WeatherCondition = "Rainy"
                        },
                        new
                        {
                            Id = new Guid("fc8839a8-c22f-4f17-ba6f-7c7b9d0dd420"),
                            CityName = "Houston",
                            LastUpdated = new DateTime(2025, 3, 8, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4763),
                            Temperature = 30.1m,
                            WeatherCondition = "Sunny"
                        },
                        new
                        {
                            Id = new Guid("34cfb2af-2a58-4df1-87d8-b0872c0c8e45"),
                            CityName = "Phoenix",
                            LastUpdated = new DateTime(2025, 3, 7, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4775),
                            Temperature = 35.6m,
                            WeatherCondition = "Sunny"
                        },
                        new
                        {
                            Id = new Guid("6091f815-d8ac-4fa3-94bd-f7aa650b3c70"),
                            CityName = "Philadelphia",
                            LastUpdated = new DateTime(2025, 3, 6, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4780),
                            Temperature = 18.9m,
                            WeatherCondition = "Windy"
                        },
                        new
                        {
                            Id = new Guid("8f4f259d-93c0-43ac-933c-adb33519da2a"),
                            CityName = "San Antonio",
                            LastUpdated = new DateTime(2025, 3, 5, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4783),
                            Temperature = 29.3m,
                            WeatherCondition = "Rainy"
                        },
                        new
                        {
                            Id = new Guid("a8dac547-f799-4787-b394-676d986f5808"),
                            CityName = "San Diego",
                            LastUpdated = new DateTime(2025, 3, 4, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4785),
                            Temperature = 24.5m,
                            WeatherCondition = "Foggy"
                        },
                        new
                        {
                            Id = new Guid("c775cdd5-904e-4d54-ace5-f3232b0a28e7"),
                            CityName = "Dallas",
                            LastUpdated = new DateTime(2025, 3, 3, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4787),
                            Temperature = 32.2m,
                            WeatherCondition = "Sunny"
                        },
                        new
                        {
                            Id = new Guid("c3c7b42d-84e5-4b7b-87e6-86d61170620d"),
                            CityName = "San Jose",
                            LastUpdated = new DateTime(2025, 3, 2, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4791),
                            Temperature = 26.4m,
                            WeatherCondition = "Cloudy"
                        },
                        new
                        {
                            Id = new Guid("3d74a7d0-2135-4195-9a34-cd19d762a368"),
                            CityName = "Austin",
                            LastUpdated = new DateTime(2025, 3, 1, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4793),
                            Temperature = 28.5m,
                            WeatherCondition = "Stormy"
                        },
                        new
                        {
                            Id = new Guid("823f98d8-57b4-4306-a4fc-36d7e042cbb7"),
                            CityName = "Jacksonville",
                            LastUpdated = new DateTime(2025, 2, 28, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4796),
                            Temperature = 22.0m,
                            WeatherCondition = "Rainy"
                        },
                        new
                        {
                            Id = new Guid("0b3777aa-c28b-4d92-bd01-8cbe8fb7012e"),
                            CityName = "Fort Worth",
                            LastUpdated = new DateTime(2025, 2, 27, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4801),
                            Temperature = 31.5m,
                            WeatherCondition = "Sunny"
                        },
                        new
                        {
                            Id = new Guid("e3ac7f2c-0ea3-49cd-b013-e7b538b4eb63"),
                            CityName = "Columbus",
                            LastUpdated = new DateTime(2025, 2, 26, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4803),
                            Temperature = 20.3m,
                            WeatherCondition = "Cloudy"
                        },
                        new
                        {
                            Id = new Guid("4e47731b-11df-474b-8986-95b35a28c0ad"),
                            CityName = "Charlotte",
                            LastUpdated = new DateTime(2025, 2, 25, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4806),
                            Temperature = 25.1m,
                            WeatherCondition = "Windy"
                        },
                        new
                        {
                            Id = new Guid("e9159122-fcb8-4d09-9a31-681b7714dd5f"),
                            CityName = "San Francisco",
                            LastUpdated = new DateTime(2025, 2, 24, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4808),
                            Temperature = 19.8m,
                            WeatherCondition = "Foggy"
                        },
                        new
                        {
                            Id = new Guid("88449bae-d056-46f4-84c6-d0adf629181d"),
                            CityName = "Indianapolis",
                            LastUpdated = new DateTime(2025, 2, 23, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4810),
                            Temperature = 17.4m,
                            WeatherCondition = "Rainy"
                        },
                        new
                        {
                            Id = new Guid("0d1adbdc-4600-40fe-a373-d66daa80bf1f"),
                            CityName = "Seattle",
                            LastUpdated = new DateTime(2025, 2, 22, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4814),
                            Temperature = 21.9m,
                            WeatherCondition = "Cloudy"
                        },
                        new
                        {
                            Id = new Guid("e3dfc7ae-2c7e-434d-a036-e7c1c7d39e85"),
                            CityName = "Denver",
                            LastUpdated = new DateTime(2025, 2, 21, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4817),
                            Temperature = 16.3m,
                            WeatherCondition = "Sunny"
                        },
                        new
                        {
                            Id = new Guid("fbcff8e9-42d4-4073-9ae3-4226ad161efb"),
                            CityName = "Washington",
                            LastUpdated = new DateTime(2025, 2, 20, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4819),
                            Temperature = 20.7m,
                            WeatherCondition = "Windy"
                        },
                        new
                        {
                            Id = new Guid("9db68759-ec29-409c-a74e-d9064b459c9b"),
                            CityName = "Boston",
                            LastUpdated = new DateTime(2025, 2, 19, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4824),
                            Temperature = 14.2m,
                            WeatherCondition = "Rainy"
                        },
                        new
                        {
                            Id = new Guid("7212fc4b-b23a-4b6d-b44e-c85bd4a090a8"),
                            CityName = "El Paso",
                            LastUpdated = new DateTime(2025, 2, 18, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4826),
                            Temperature = 27.6m,
                            WeatherCondition = "Sunny"
                        },
                        new
                        {
                            Id = new Guid("5d2f42f8-d3eb-4156-8e16-ccb45e0ab9d0"),
                            CityName = "Nashville",
                            LastUpdated = new DateTime(2025, 2, 17, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4829),
                            Temperature = 22.9m,
                            WeatherCondition = "Cloudy"
                        },
                        new
                        {
                            Id = new Guid("c2034ec1-1bba-40da-a9b8-6636f3804a56"),
                            CityName = "Detroit",
                            LastUpdated = new DateTime(2025, 2, 16, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4831),
                            Temperature = 19.1m,
                            WeatherCondition = "Foggy"
                        },
                        new
                        {
                            Id = new Guid("f771d133-2812-4e9d-a587-f65085f3f599"),
                            CityName = "Oklahoma City",
                            LastUpdated = new DateTime(2025, 2, 15, 23, 23, 55, 313, DateTimeKind.Local).AddTicks(4833),
                            Temperature = 30.0m,
                            WeatherCondition = "Sunny"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
