using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarApi.Migrations
{
    /// <inheritdoc />
    public partial class addedDbInitializer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("34af3d8b-4b2a-4317-b254-3206c3a1124f"), new DateTime(1995, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "img_cruz@gmail.com", "John Cruz", "LongCruz11" },
                    { new Guid("c2539447-ed58-4e0b-8175-5d7745210a2b"), new DateTime(1993, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "nathaniel.carballo@gmail.com", "Nathaniel Carballo", "NCar10" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "Make", "Model", "Price", "UserId", "Year" },
                values: new object[,]
                {
                    { new Guid("8ac2e11d-d7b8-430d-ab32-2582c3b16a22"), "Red", "Ford", "Mustang", 1895f, new Guid("34af3d8b-4b2a-4317-b254-3206c3a1124f"), 1997 },
                    { new Guid("f87db22f-bbf3-49d5-9d7a-a20a20f2b975"), "Black", "Dodge", "Challenger", 45000f, new Guid("c2539447-ed58-4e0b-8175-5d7745210a2b"), 2018 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("8ac2e11d-d7b8-430d-ab32-2582c3b16a22"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("f87db22f-bbf3-49d5-9d7a-a20a20f2b975"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("34af3d8b-4b2a-4317-b254-3206c3a1124f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c2539447-ed58-4e0b-8175-5d7745210a2b"));
        }
    }
}
