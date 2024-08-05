using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreEncapsulation.Api.Migrations
{
    public partial class Remove_Properties_From_Enrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Classes_FK_Enrollments_Classes_ClassId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Members_FK_Enrollments_Members_MemberId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_FK_Enrollments_Classes_ClassId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_FK_Enrollments_Members_MemberId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "FK_Enrollments_Classes_ClassId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "FK_Enrollments_Members_MemberId",
                table: "Enrollments");

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "ClassId", "MemberId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ClassId",
                table: "Enrollments",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Classes_ClassId",
                table: "Enrollments",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Members_MemberId",
                table: "Enrollments",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Classes_ClassId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Members_MemberId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_ClassId",
                table: "Enrollments");

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "ClassId", "MemberId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "ClassId", "MemberId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "ClassId", "MemberId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "ClassId", "MemberId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.AddColumn<int>(
                name: "FK_Enrollments_Classes_ClassId",
                table: "Enrollments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FK_Enrollments_Members_MemberId",
                table: "Enrollments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2024, 8, 5, 15, 25, 57, 666, DateTimeKind.Local).AddTicks(409));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2024, 8, 5, 15, 25, 57, 666, DateTimeKind.Local).AddTicks(442));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2024, 8, 5, 15, 25, 57, 666, DateTimeKind.Local).AddTicks(443));

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_FK_Enrollments_Classes_ClassId",
                table: "Enrollments",
                column: "FK_Enrollments_Classes_ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_FK_Enrollments_Members_MemberId",
                table: "Enrollments",
                column: "FK_Enrollments_Members_MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Classes_FK_Enrollments_Classes_ClassId",
                table: "Enrollments",
                column: "FK_Enrollments_Classes_ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Members_FK_Enrollments_Members_MemberId",
                table: "Enrollments",
                column: "FK_Enrollments_Members_MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
