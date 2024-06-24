using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 1,
                column: "date",
                value: new DateTime(2024, 6, 23, 16, 39, 21, 744, DateTimeKind.Local).AddTicks(8057));

            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 2,
                column: "date",
                value: new DateTime(2024, 6, 23, 16, 39, 21, 744, DateTimeKind.Local).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 3,
                column: "date",
                value: new DateTime(2024, 6, 23, 16, 39, 21, 744, DateTimeKind.Local).AddTicks(8070));

            migrationBuilder.InsertData(
                table: "ProductStores",
                columns: new[] { "id", "branch_store_id", "date", "is_active", "product_id" },
                values: new object[,]
                {
                    { 4, 1, new DateTime(2024, 6, 23, 16, 39, 21, 744, DateTimeKind.Local).AddTicks(8071), true, 4 },
                    { 5, 1, new DateTime(2024, 6, 23, 16, 39, 21, 744, DateTimeKind.Local).AddTicks(8072), true, 5 },
                    { 6, 1, new DateTime(2024, 6, 23, 16, 39, 21, 744, DateTimeKind.Local).AddTicks(8073), true, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 1,
                column: "date",
                value: new DateTime(2024, 6, 23, 16, 12, 15, 264, DateTimeKind.Local).AddTicks(3039));

            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 2,
                column: "date",
                value: new DateTime(2024, 6, 23, 16, 12, 15, 264, DateTimeKind.Local).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 3,
                column: "date",
                value: new DateTime(2024, 6, 23, 16, 12, 15, 264, DateTimeKind.Local).AddTicks(3056));
        }
    }
}
