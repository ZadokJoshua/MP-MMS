using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MP_MMS.Data.Migrations
{
    public partial class PartImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 7, 6, 2, 40, 44, 562, DateTimeKind.Local).AddTicks(2108));

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2023, 7, 10, 2, 40, 44, 562, DateTimeKind.Local).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2023, 7, 6, 2, 40, 44, 562, DateTimeKind.Local).AddTicks(2119));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 7, 5, 2, 40, 44, 562, DateTimeKind.Local).AddTicks(2028));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 7, 5, 2, 40, 44, 562, DateTimeKind.Local).AddTicks(2046));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 7, 5, 2, 40, 44, 562, DateTimeKind.Local).AddTicks(2050));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 7, 5, 2, 40, 44, 562, DateTimeKind.Local).AddTicks(2054));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 7, 5, 2, 40, 44, 562, DateTimeKind.Local).AddTicks(2057));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 7, 5, 2, 40, 44, 562, DateTimeKind.Local).AddTicks(2062));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2022, 11, 19, 17, 28, 56, 830, DateTimeKind.Local).AddTicks(895));

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2022, 11, 23, 17, 28, 56, 830, DateTimeKind.Local).AddTicks(903));

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2022, 11, 19, 17, 28, 56, 830, DateTimeKind.Local).AddTicks(906));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 11, 18, 17, 28, 56, 830, DateTimeKind.Local).AddTicks(781));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 11, 18, 17, 28, 56, 830, DateTimeKind.Local).AddTicks(809));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 11, 18, 17, 28, 56, 830, DateTimeKind.Local).AddTicks(815));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 11, 18, 17, 28, 56, 830, DateTimeKind.Local).AddTicks(819));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 11, 18, 17, 28, 56, 830, DateTimeKind.Local).AddTicks(824));

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 11, 18, 17, 28, 56, 830, DateTimeKind.Local).AddTicks(828));
        }
    }
}
