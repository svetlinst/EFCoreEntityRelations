using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_StudentSystem.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2019, 8, 4, 15, 29, 14, 962, DateTimeKind.Local).AddTicks(3780), new DateTime(2019, 7, 5, 15, 29, 14, 955, DateTimeKind.Local).AddTicks(5586) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "RegisteredOn",
                value: new DateTime(2019, 7, 5, 15, 29, 14, 969, DateTimeKind.Local).AddTicks(6121));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "RegisteredOn",
                value: new DateTime(2019, 7, 6, 15, 29, 14, 969, DateTimeKind.Local).AddTicks(7855));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2019, 7, 10, 23, 32, 8, 585, DateTimeKind.Local).AddTicks(103), new DateTime(2019, 6, 10, 23, 32, 8, 582, DateTimeKind.Local).AddTicks(2295) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "RegisteredOn",
                value: new DateTime(2019, 6, 10, 23, 32, 8, 588, DateTimeKind.Local).AddTicks(2118));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "RegisteredOn",
                value: new DateTime(2019, 6, 11, 23, 32, 8, 588, DateTimeKind.Local).AddTicks(2946));
        }
    }
}
