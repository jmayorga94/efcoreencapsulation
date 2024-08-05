using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreEncapsulation.Api.Migrations
{
    public partial class Seed_Payment_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2024, 8, 5, 16, 43, 11, 753, DateTimeKind.Local).AddTicks(7651));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2024, 8, 5, 16, 43, 11, 753, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2024, 8, 5, 16, 43, 11, 753, DateTimeKind.Local).AddTicks(7688));

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "MemberId", "PaymentDate" },
                values: new object[,]
                {
                    { 1, 50.00m, 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 75.00m, 1, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 60.00m, 2, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2024, 8, 5, 16, 36, 46, 709, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2024, 8, 5, 16, 36, 46, 709, DateTimeKind.Local).AddTicks(5975));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2024, 8, 5, 16, 36, 46, 709, DateTimeKind.Local).AddTicks(5977));
        }
    }
}
