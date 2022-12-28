using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Product_productId",
                table: "Inventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories");

            migrationBuilder.RenameTable(
                name: "Inventories",
                newName: "Storages");

            migrationBuilder.RenameIndex(
                name: "IX_Inventories_productId",
                table: "Storages",
                newName: "IX_Storages_productId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Storages",
                table: "Storages",
                column: "storageId");

            migrationBuilder.UpdateData(
                table: "EmployedAts",
                keyColumns: new[] { "retailId", "staffId" },
                keyValues: new object[] { 1, 1 },
                column: "employedSince",
                value: new DateTime(2022, 12, 28, 13, 5, 40, 90, DateTimeKind.Local).AddTicks(238));

            migrationBuilder.UpdateData(
                table: "EmployedAts",
                keyColumns: new[] { "retailId", "staffId" },
                keyValues: new object[] { 2, 2 },
                column: "employedSince",
                value: new DateTime(2022, 12, 28, 13, 5, 40, 90, DateTimeKind.Local).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "EmployedAts",
                keyColumns: new[] { "retailId", "staffId" },
                keyValues: new object[] { 3, 3 },
                column: "employedSince",
                value: new DateTime(2022, 12, 28, 13, 5, 40, 90, DateTimeKind.Local).AddTicks(258));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderId",
                keyValue: 1,
                column: "createdAt",
                value: new DateTime(2022, 12, 28, 13, 5, 40, 90, DateTimeKind.Local).AddTicks(280));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderId",
                keyValue: 2,
                column: "createdAt",
                value: new DateTime(2022, 12, 28, 13, 5, 40, 90, DateTimeKind.Local).AddTicks(291));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderId",
                keyValue: 3,
                column: "createdAt",
                value: new DateTime(2022, 12, 28, 13, 5, 40, 90, DateTimeKind.Local).AddTicks(295));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "personId",
                keyValue: 1,
                column: "dateOfBirth",
                value: new DateTime(2022, 12, 28, 13, 5, 40, 90, DateTimeKind.Local).AddTicks(318));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "personId",
                keyValue: 2,
                column: "dateOfBirth",
                value: new DateTime(2022, 12, 28, 13, 5, 40, 90, DateTimeKind.Local).AddTicks(323));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "personId",
                keyValue: 3,
                column: "dateOfBirth",
                value: new DateTime(2022, 12, 28, 13, 5, 40, 90, DateTimeKind.Local).AddTicks(327));

            migrationBuilder.UpdateData(
                table: "Refunds",
                keyColumn: "refundId",
                keyValue: 1,
                column: "createdAt",
                value: new DateTime(2022, 12, 28, 13, 5, 40, 90, DateTimeKind.Local).AddTicks(386));

            migrationBuilder.UpdateData(
                table: "Refunds",
                keyColumn: "refundId",
                keyValue: 2,
                column: "createdAt",
                value: new DateTime(2022, 12, 28, 13, 5, 40, 90, DateTimeKind.Local).AddTicks(390));

            migrationBuilder.UpdateData(
                table: "Refunds",
                keyColumn: "refundId",
                keyValue: 3,
                column: "createdAt",
                value: new DateTime(2022, 12, 28, 13, 5, 40, 90, DateTimeKind.Local).AddTicks(392));

            migrationBuilder.UpdateData(
                table: "Supplyings",
                keyColumn: "supplyingId",
                keyValue: 1,
                columns: new[] { "arrivedAt", "orderedAt" },
                values: new object[] { new DateTime(2022, 12, 28, 13, 5, 40, 90, DateTimeKind.Local).AddTicks(506), new DateTime(2022, 12, 28, 13, 5, 40, 90, DateTimeKind.Local).AddTicks(507) });

            migrationBuilder.UpdateData(
                table: "Supplyings",
                keyColumn: "supplyingId",
                keyValue: 2,
                columns: new[] { "arrivedAt", "orderedAt" },
                values: new object[] { new DateTime(2022, 12, 28, 13, 5, 40, 90, DateTimeKind.Local).AddTicks(511), new DateTime(2022, 12, 28, 13, 5, 40, 90, DateTimeKind.Local).AddTicks(513) });

            migrationBuilder.UpdateData(
                table: "Supplyings",
                keyColumn: "supplyingId",
                keyValue: 3,
                columns: new[] { "arrivedAt", "orderedAt" },
                values: new object[] { new DateTime(2022, 12, 28, 13, 5, 40, 90, DateTimeKind.Local).AddTicks(515), new DateTime(2022, 12, 28, 13, 5, 40, 90, DateTimeKind.Local).AddTicks(516) });

            migrationBuilder.AddForeignKey(
                name: "FK_Storages_Product_productId",
                table: "Storages",
                column: "productId",
                principalTable: "Product",
                principalColumn: "productId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Storages_Product_productId",
                table: "Storages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Storages",
                table: "Storages");

            migrationBuilder.RenameTable(
                name: "Storages",
                newName: "Inventories");

            migrationBuilder.RenameIndex(
                name: "IX_Storages_productId",
                table: "Inventories",
                newName: "IX_Inventories_productId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories",
                column: "storageId");

            migrationBuilder.UpdateData(
                table: "EmployedAts",
                keyColumns: new[] { "retailId", "staffId" },
                keyValues: new object[] { 1, 1 },
                column: "employedSince",
                value: new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5384));

            migrationBuilder.UpdateData(
                table: "EmployedAts",
                keyColumns: new[] { "retailId", "staffId" },
                keyValues: new object[] { 2, 2 },
                column: "employedSince",
                value: new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5396));

            migrationBuilder.UpdateData(
                table: "EmployedAts",
                keyColumns: new[] { "retailId", "staffId" },
                keyValues: new object[] { 3, 3 },
                column: "employedSince",
                value: new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5398));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderId",
                keyValue: 1,
                column: "createdAt",
                value: new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderId",
                keyValue: 2,
                column: "createdAt",
                value: new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5417));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderId",
                keyValue: 3,
                column: "createdAt",
                value: new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5421));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "personId",
                keyValue: 1,
                column: "dateOfBirth",
                value: new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5435));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "personId",
                keyValue: 2,
                column: "dateOfBirth",
                value: new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5439));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "personId",
                keyValue: 3,
                column: "dateOfBirth",
                value: new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5442));

            migrationBuilder.UpdateData(
                table: "Refunds",
                keyColumn: "refundId",
                keyValue: 1,
                column: "createdAt",
                value: new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5486));

            migrationBuilder.UpdateData(
                table: "Refunds",
                keyColumn: "refundId",
                keyValue: 2,
                column: "createdAt",
                value: new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "Refunds",
                keyColumn: "refundId",
                keyValue: 3,
                column: "createdAt",
                value: new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5492));

            migrationBuilder.UpdateData(
                table: "Supplyings",
                keyColumn: "supplyingId",
                keyValue: 1,
                columns: new[] { "arrivedAt", "orderedAt" },
                values: new object[] { new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5532), new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5533) });

            migrationBuilder.UpdateData(
                table: "Supplyings",
                keyColumn: "supplyingId",
                keyValue: 2,
                columns: new[] { "arrivedAt", "orderedAt" },
                values: new object[] { new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5535), new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5537) });

            migrationBuilder.UpdateData(
                table: "Supplyings",
                keyColumn: "supplyingId",
                keyValue: 3,
                columns: new[] { "arrivedAt", "orderedAt" },
                values: new object[] { new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5573), new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5575) });

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Product_productId",
                table: "Inventories",
                column: "productId",
                principalTable: "Product",
                principalColumn: "productId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
