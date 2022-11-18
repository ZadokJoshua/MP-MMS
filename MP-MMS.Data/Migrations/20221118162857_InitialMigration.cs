using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MP_MMS.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModelNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parts_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issues_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Issues_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Role" },
                values: new object[,]
                {
                    { 1, "mikejonathan@mpmms.com", "Mike", "Jonathan", "Electrician" },
                    { 2, "susanaaron@mpmms.com", "Susan", "Aaron", "Safety officer" },
                    { 3, "barnabasotee@mpmms.com", "Barnabas", "Otee", "CNC Operator" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "SIPET, Mechanical Engineering Building, Gidan-Kwanu Campus, Minna", "Mechanical Engineering Workshop 1" },
                    { 2, "Opposite Engineering Complex, Gidan-Kwanu Campus, Minna", "Mechanical Engineering Workshop 2" },
                    { 3, "Opposite Engineering Complex, Gidan-Kwanu Campus, Minna", "CNC Workshop 1" },
                    { 4, "Physics Department, Bosso Campus, Minna", "Milling Workshop 1" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { 1, "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Category", "DateAdded", "LocationId", "Manufacturer", "ModelNumber", "Name", "Quantity", "SerialNumber", "UnitCost" },
                values: new object[,]
                {
                    { 1, "Actuator", new DateTime(2022, 11, 18, 17, 28, 56, 830, DateTimeKind.Local).AddTicks(781), 1, "McMaster Engineering Limited", "C5-1", "Face-Mount AC Motors", 3, "732675", 1200m },
                    { 2, "Others", new DateTime(2022, 11, 18, 17, 28, 56, 830, DateTimeKind.Local).AddTicks(809), 3, "Fiberglass Engineering", "ADW-4F", "Auto-Darkening Welding Helmets", 2, "N/A", 3200m },
                    { 3, "Others", new DateTime(2022, 11, 18, 17, 28, 56, 830, DateTimeKind.Local).AddTicks(815), 3, "Fiberglass Engineering", "WWG-2F", "Wraparound Welding Glasses", 30, "N/A", 200m },
                    { 4, "Belt", new DateTime(2022, 11, 18, 17, 28, 56, 830, DateTimeKind.Local).AddTicks(819), 2, "McMaster Engineering Limited", "SPCON-A2", "Sprockets for Conveyor Chain Belts", 12, "263712", 1200m },
                    { 5, "Others", new DateTime(2022, 11, 18, 17, 28, 56, 830, DateTimeKind.Local).AddTicks(824), 1, "BlueLight", "T3-CAS", "Compressed Air Storage Tank", 1, "9888K9", 5500m },
                    { 6, "Bearing", new DateTime(2022, 11, 18, 17, 28, 56, 830, DateTimeKind.Local).AddTicks(828), 2, "McMaster Engineering Limited", "N/A", "Bearings for suspension system", 2, "4712", 50m }
                });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "Description", "DueDate", "EmployeeId", "IsCompleted", "Name", "PartId", "Priority" },
                values: new object[] { 1, "Replace damage bearings.", new DateTime(2022, 11, 19, 17, 28, 56, 830, DateTimeKind.Local).AddTicks(895), 1, false, "Damage Bearings", 6, "Medium" });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "Description", "DueDate", "EmployeeId", "IsCompleted", "Name", "PartId", "Priority" },
                values: new object[] { 2, "Replace broken welding helmet screen with the newer screen that are available in store 1.", new DateTime(2022, 11, 23, 17, 28, 56, 830, DateTimeKind.Local).AddTicks(903), 2, true, "Broken welding helmet screen", 2, "Low" });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "Description", "DueDate", "EmployeeId", "IsCompleted", "Name", "PartId", "Priority" },
                values: new object[] { 3, "There's is a leakage at the bottom of the Compressed Air Storage Tank. Please work together with the welder to fix the issue.", new DateTime(2022, 11, 19, 17, 28, 56, 830, DateTimeKind.Local).AddTicks(906), 2, false, "Tank leakage", 5, "Medium" });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_EmployeeId",
                table: "Issues",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_PartId",
                table: "Issues",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_LocationId",
                table: "Parts",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
