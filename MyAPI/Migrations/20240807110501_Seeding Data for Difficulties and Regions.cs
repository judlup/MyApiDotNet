using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("25ff9e69-0b60-4643-8320-973662ee2e15"), "Hard" },
                    { new Guid("b2b42162-1c2a-4da1-9978-d5df0f3551e9"), "Moderate" },
                    { new Guid("ec689ad5-2d6f-4011-a005-6af5b39ecd83"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("39528d95-4f8f-48d9-a685-aded7b946f2f"), "S", "South", "s.jpg" },
                    { new Guid("938f4c68-7e31-4427-ab38-48c9f3cdf683"), "E", "East", "e.jpg" },
                    { new Guid("b6803ecb-f2a9-4497-94b8-672bab7bf629"), "W", "West", "w.jpg" },
                    { new Guid("d889a6b8-7bea-40a4-be8b-b21c9eda2a51"), "N", "North", "n.pjg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("25ff9e69-0b60-4643-8320-973662ee2e15"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b2b42162-1c2a-4da1-9978-d5df0f3551e9"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ec689ad5-2d6f-4011-a005-6af5b39ecd83"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("39528d95-4f8f-48d9-a685-aded7b946f2f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("938f4c68-7e31-4427-ab38-48c9f3cdf683"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b6803ecb-f2a9-4497-94b8-672bab7bf629"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d889a6b8-7bea-40a4-be8b-b21c9eda2a51"));
        }
    }
}
