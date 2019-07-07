using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_StudentSystem.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Description", "EndDate", "Name", "Price", "StartDate" },
                values: new object[] { 1, "Microsoft", new DateTime(2019, 7, 10, 23, 32, 8, 585, DateTimeKind.Local).AddTicks(103), "C++", 100m, new DateTime(2019, 6, 10, 23, 32, 8, 582, DateTimeKind.Local).AddTicks(2295) });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Birthday", "Name", "PhoneNumber", "RegisteredOn" },
                values: new object[] { 1, null, "Pesho", "0123456789", new DateTime(2019, 6, 10, 23, 32, 8, 588, DateTimeKind.Local).AddTicks(2118) });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Birthday", "Name", "PhoneNumber", "RegisteredOn" },
                values: new object[] { 2, null, "Gosho", "0123456789", new DateTime(2019, 6, 11, 23, 32, 8, 588, DateTimeKind.Local).AddTicks(2946) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);
        }
    }
}
