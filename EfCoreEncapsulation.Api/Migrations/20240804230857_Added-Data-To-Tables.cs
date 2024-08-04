using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreEncapsulation.Api.Migrations
{
    public partial class AddedDataToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "ClassName", "Instructor" },
                values: new object[,]
                {
                    { 1, "Yoga", "Alice Johnson" },
                    { 2, "Pilates", "Bob Brown" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "MembershipStartDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 4, 19, 8, 57, 222, DateTimeKind.Local).AddTicks(4915), "John Doe" },
                    { 2, new DateTime(2024, 8, 4, 19, 8, 57, 222, DateTimeKind.Local).AddTicks(4945), "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "ClassId", "MemberId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "ClassId", "MemberId" },
                values: new object[] { 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "ClassId", "MemberId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "ClassId", "MemberId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2);
        }
    }
}
