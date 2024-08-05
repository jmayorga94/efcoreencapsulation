using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreEncapsulation.Api.Migrations
{
    public partial class Add_Payment_Table_To_Db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentId", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MemberId",
                table: "Payments",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2024, 8, 5, 15, 28, 10, 822, DateTimeKind.Local).AddTicks(3844));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2024, 8, 5, 15, 28, 10, 822, DateTimeKind.Local).AddTicks(3883));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2024, 8, 5, 15, 28, 10, 822, DateTimeKind.Local).AddTicks(3884));
        }
    }
}
