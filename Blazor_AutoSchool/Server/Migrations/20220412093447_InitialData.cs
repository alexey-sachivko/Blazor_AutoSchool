using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazor_AutoSchool.Server.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfManufacture",
                table: "Autos",
                newName: "YearOfManufacture");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Birthday", "Contact", "Name", "Passport", "PasswordHash", "PasswordSalt", "Role", "Surname", "ThirdName", "Username" },
                values: new object[] { 1, "1600 Pennsylvania Avenue NW, Washington, DC 20500", new DateTime(1982, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "1-891-456-3476", " Joe", "31195855", new byte[] { 32, 32, 32, 32, 32, 32, 32 }, new byte[] { 32, 32, 32, 32, 32, 32, 32 }, "Admin", "John", "Adam", "admin" });

            migrationBuilder.InsertData(
                table: "Autos",
                columns: new[] { "Id", "Brand", "Color", "EmployeeId", "Model", "RegistrationNumber", "Status", "Type", "YearOfManufacture" },
                values: new object[] { 1, "BMW", "Black", 1, "3 Series", "3YU-89I", "In action", "Passenger Car", "2020" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "YearOfManufacture",
                table: "Autos",
                newName: "DateOfManufacture");
        }
    }
}
