using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration_v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 1,
                column: "date",
                value: new DateTime(2024, 6, 23, 21, 36, 39, 254, DateTimeKind.Local).AddTicks(9591));

            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 2,
                column: "date",
                value: new DateTime(2024, 6, 23, 21, 36, 39, 254, DateTimeKind.Local).AddTicks(9606));

            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 3,
                column: "date",
                value: new DateTime(2024, 6, 23, 21, 36, 39, 254, DateTimeKind.Local).AddTicks(9607));

            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 4,
                column: "date",
                value: new DateTime(2024, 6, 23, 21, 36, 39, 254, DateTimeKind.Local).AddTicks(9608));

            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 5,
                column: "date",
                value: new DateTime(2024, 6, 23, 21, 36, 39, 254, DateTimeKind.Local).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 6,
                column: "date",
                value: new DateTime(2024, 6, 23, 21, 36, 39, 254, DateTimeKind.Local).AddTicks(9610));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Purchases");

            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 1,
                column: "date",
                value: new DateTime(2024, 6, 23, 19, 55, 50, 428, DateTimeKind.Local).AddTicks(5875));

            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 2,
                column: "date",
                value: new DateTime(2024, 6, 23, 19, 55, 50, 428, DateTimeKind.Local).AddTicks(5891));

            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 3,
                column: "date",
                value: new DateTime(2024, 6, 23, 19, 55, 50, 428, DateTimeKind.Local).AddTicks(5892));

            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 4,
                column: "date",
                value: new DateTime(2024, 6, 23, 19, 55, 50, 428, DateTimeKind.Local).AddTicks(5893));

            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 5,
                column: "date",
                value: new DateTime(2024, 6, 23, 19, 55, 50, 428, DateTimeKind.Local).AddTicks(5894));

            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 6,
                column: "date",
                value: new DateTime(2024, 6, 23, 19, 55, 50, 428, DateTimeKind.Local).AddTicks(5895));
        }
    }
}
