using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MP_MMS.Data.Migrations
{
    public partial class removingWrongColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "PartName",
                table: "Issues");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "Parts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PartName",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
