using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazor_AutoSchool.Server.Migrations
{
    public partial class GroupInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CategoryId", "Description", "EmployeeId", "EndDate", "GroupNumber", "StartDate" },
                values: new object[] { 1, 2, "Example text.", 1, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
