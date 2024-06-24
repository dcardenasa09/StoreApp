using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "stock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "BranchStores",
                columns: new[] { "id", "address", "branch", "is_active" },
                values: new object[] { 1, "Calle 128 #321, CP 9700, Centro, Merida, Yucatan", "Sucursal Mérida", true });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "description", "is_active", "key", "price", "stock", "url_image" },
                values: new object[,]
                {
                    { 1, "Producto 1", true, "PROD1", 19.99m, 100, "image1.jpg" },
                    { 2, "Producto 2", true, "PROD2", 29.99m, 50, "image2.jpg" },
                    { 3, "Producto 3", true, "PROD3", 39.99m, 200, "image3.jpg" },
                    { 4, "Producto 4", true, "PROD4", 29.99m, 150, "image4.jpg" },
                    { 5, "Producto 5", true, "PROD5", 29.99m, 150, "image5.jpg" },
                    { 6, "Producto 6", true, "PROD6", 59.99m, 20, "image6.jpg" }
                });

            migrationBuilder.InsertData(
                table: "ProductStores",
                columns: new[] { "id", "branch_store_id", "date", "is_active", "product_id" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 23, 16, 12, 15, 264, DateTimeKind.Local).AddTicks(3039), true, 1 },
                    { 2, 1, new DateTime(2024, 6, 23, 16, 12, 15, 264, DateTimeKind.Local).AddTicks(3055), true, 2 },
                    { 3, 1, new DateTime(2024, 6, 23, 16, 12, 15, 264, DateTimeKind.Local).AddTicks(3056), true, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BranchStores",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "stock",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
