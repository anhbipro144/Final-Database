using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Final.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployedAts_RetailChains_RetailChainretailId",
                table: "EmployedAts");

            migrationBuilder.DropTable(
                name: "Product_Orders");

            migrationBuilder.DropTable(
                name: "RetailChains");

            migrationBuilder.DropIndex(
                name: "IX_EmployedAts_RetailChainretailId",
                table: "EmployedAts");

            migrationBuilder.DropColumn(
                name: "RetailChainretailId",
                table: "EmployedAts");

            migrationBuilder.RenameColumn(
                name: "inventoryId",
                table: "Inventories",
                newName: "storageId");

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    countingUnit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.orderId, x.productId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_orderId",
                        column: x => x.orderId,
                        principalTable: "Orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Retails",
                columns: table => new
                {
                    retailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retails", x => x.retailId);
                });

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

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "orderId", "productId", "countingUnit", "quantity", "total" },
                values: new object[,]
                {
                    { 1, 1, "chiec", 10, 100m },
                    { 2, 2, "chiec", 20, 200m },
                    { 3, 3, "chiec", 30, 300m }
                });

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
                columns: new[] { "createdAt", "reason" },
                values: new object[] { new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5486), "FOr no reason" });

            migrationBuilder.UpdateData(
                table: "Refunds",
                keyColumn: "refundId",
                keyValue: 2,
                columns: new[] { "createdAt", "reason" },
                values: new object[] { new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5490), "For no reason again!" });

            migrationBuilder.UpdateData(
                table: "Refunds",
                keyColumn: "refundId",
                keyValue: 3,
                columns: new[] { "createdAt", "reason" },
                values: new object[] { new DateTime(2022, 12, 28, 12, 59, 41, 811, DateTimeKind.Local).AddTicks(5492), "Just like it" });

            migrationBuilder.InsertData(
                table: "Retails",
                columns: new[] { "retailId", "address", "name" },
                values: new object[,]
                {
                    { 1, "156, Duong 3/2", "Retail1" },
                    { 2, "326, Nguyen Tri Phuong", "Retail2" },
                    { 3, "221, Hoa Hao", "Retail3" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_EmployedAts_retailId",
                table: "EmployedAts",
                column: "retailId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_productId",
                table: "OrderItems",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployedAts_Retails_retailId",
                table: "EmployedAts",
                column: "retailId",
                principalTable: "Retails",
                principalColumn: "retailId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployedAts_Retails_retailId",
                table: "EmployedAts");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Retails");

            migrationBuilder.DropIndex(
                name: "IX_EmployedAts_retailId",
                table: "EmployedAts");

            migrationBuilder.RenameColumn(
                name: "storageId",
                table: "Inventories",
                newName: "inventoryId");

            migrationBuilder.AddColumn<int>(
                name: "RetailChainretailId",
                table: "EmployedAts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Product_Orders",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    countingUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Orders", x => new { x.orderId, x.productId });
                    table.ForeignKey(
                        name: "FK_Product_Orders_Orders_orderId",
                        column: x => x.orderId,
                        principalTable: "Orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Orders_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RetailChains",
                columns: table => new
                {
                    retailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetailChains", x => x.retailId);
                });

            migrationBuilder.UpdateData(
                table: "EmployedAts",
                keyColumns: new[] { "retailId", "staffId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "RetailChainretailId", "employedSince" },
                values: new object[] { null, new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3187) });

            migrationBuilder.UpdateData(
                table: "EmployedAts",
                keyColumns: new[] { "retailId", "staffId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "RetailChainretailId", "employedSince" },
                values: new object[] { null, new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3197) });

            migrationBuilder.UpdateData(
                table: "EmployedAts",
                keyColumns: new[] { "retailId", "staffId" },
                keyValues: new object[] { 3, 3 },
                columns: new[] { "RetailChainretailId", "employedSince" },
                values: new object[] { null, new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3198) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderId",
                keyValue: 1,
                column: "createdAt",
                value: new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3209));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderId",
                keyValue: 2,
                column: "createdAt",
                value: new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3214));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderId",
                keyValue: 3,
                column: "createdAt",
                value: new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3215));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "personId",
                keyValue: 1,
                column: "dateOfBirth",
                value: new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3248));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "personId",
                keyValue: 2,
                column: "dateOfBirth",
                value: new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3251));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "personId",
                keyValue: 3,
                column: "dateOfBirth",
                value: new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3253));

            migrationBuilder.InsertData(
                table: "Product_Orders",
                columns: new[] { "orderId", "productId", "countingUnit", "quantity", "total" },
                values: new object[,]
                {
                    { 1, 1, "chiec", 10, 100m },
                    { 2, 2, "chiec", 20, 200m },
                    { 3, 3, "chiec", 30, 300m }
                });

            migrationBuilder.UpdateData(
                table: "Refunds",
                keyColumn: "refundId",
                keyValue: 1,
                columns: new[] { "createdAt", "reason" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3281), "Tai t thich" });

            migrationBuilder.UpdateData(
                table: "Refunds",
                keyColumn: "refundId",
                keyValue: 2,
                columns: new[] { "createdAt", "reason" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3283), "Tai t thich duoc k?" });

            migrationBuilder.UpdateData(
                table: "Refunds",
                keyColumn: "refundId",
                keyValue: 3,
                columns: new[] { "createdAt", "reason" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3284), "Tai t lai thich" });

            migrationBuilder.InsertData(
                table: "RetailChains",
                columns: new[] { "retailId", "address", "name" },
                values: new object[,]
                {
                    { 1, "156, Duong 3/2", "Retail1" },
                    { 2, "326, Nguyen Tri Phuong", "Retail2" },
                    { 3, "221, Hoa Hao", "Retail3" }
                });

            migrationBuilder.UpdateData(
                table: "Supplyings",
                keyColumn: "supplyingId",
                keyValue: 1,
                columns: new[] { "arrivedAt", "orderedAt" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3311), new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3312) });

            migrationBuilder.UpdateData(
                table: "Supplyings",
                keyColumn: "supplyingId",
                keyValue: 2,
                columns: new[] { "arrivedAt", "orderedAt" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3313), new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3314) });

            migrationBuilder.UpdateData(
                table: "Supplyings",
                keyColumn: "supplyingId",
                keyValue: 3,
                columns: new[] { "arrivedAt", "orderedAt" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3315), new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3316) });

            migrationBuilder.CreateIndex(
                name: "IX_EmployedAts_RetailChainretailId",
                table: "EmployedAts",
                column: "RetailChainretailId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Orders_productId",
                table: "Product_Orders",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployedAts_RetailChains_RetailChainretailId",
                table: "EmployedAts",
                column: "RetailChainretailId",
                principalTable: "RetailChains",
                principalColumn: "retailId");
        }
    }
}
