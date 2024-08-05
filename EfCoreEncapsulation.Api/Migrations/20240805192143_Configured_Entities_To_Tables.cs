using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreEncapsulation.Api.Migrations
{
    public partial class Configured_Entities_To_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classes",
                table: "Classes");

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

            migrationBuilder.RenameColumn(
                name: "MembershipStartDate",
                table: "Members",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "ClassName",
                table: "Classes",
                newName: "Name");

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

            migrationBuilder.AddPrimaryKey(
                name: "ClassId",
                table: "Classes",
                column: "ClassId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "ClassId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "FK_Enrollments_Classes_ClassId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "FK_Enrollments_Members_MemberId",
                table: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Members",
                newName: "MembershipStartDate");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Classes",
                newName: "ClassName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classes",
                table: "Classes",
                column: "ClassId");

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
    }
}
