using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration_v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Clients_ClientId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Clients_ClientId",
                table: "AspNetUsers",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Clients_ClientId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 4,
                column: "date",
                value: new DateTime(2024, 6, 23, 16, 39, 21, 744, DateTimeKind.Local).AddTicks(8071));

            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 5,
                column: "date",
                value: new DateTime(2024, 6, 23, 16, 39, 21, 744, DateTimeKind.Local).AddTicks(8072));

            migrationBuilder.UpdateData(
                table: "ProductStores",
                keyColumn: "id",
                keyValue: 6,
                column: "date",
                value: new DateTime(2024, 6, 23, 16, 39, 21, 744, DateTimeKind.Local).AddTicks(8073));

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Clients_ClientId",
                table: "AspNetUsers",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
