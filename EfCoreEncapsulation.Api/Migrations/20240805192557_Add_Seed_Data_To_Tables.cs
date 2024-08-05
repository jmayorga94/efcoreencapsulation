using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreEncapsulation.Api.Migrations
{
    public partial class Add_Seed_Data_To_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "Name", "Instructor" },
                values: new object[,]
                {
                    { 1, "Yoga", "Alice Johnson" },
                    { 2, "Pilates", "Bob Brown" },
                    { 3, "Cycling", "Leslie Cabrera" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "StartDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 5, 15, 25, 57, 666, DateTimeKind.Local).AddTicks(409), "John Doe" },
                    { 2, new DateTime(2024, 8, 5, 15, 25, 57, 666, DateTimeKind.Local).AddTicks(442), "Jane Smith" },
                    { 3, new DateTime(2024, 8, 5, 15, 25, 57, 666, DateTimeKind.Local).AddTicks(443), "Paige Patchet" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3);
        }
    }
}
