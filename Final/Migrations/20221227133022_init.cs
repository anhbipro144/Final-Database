using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Final.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    personId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.personId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryId = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "RetailChains",
                columns: table => new
                {
                    retailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetailChains", x => x.retailId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    supplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.supplierId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customerId);
                    table.ForeignKey(
                        name: "FK_Customers_Persons_personId",
                        column: x => x.personId,
                        principalTable: "Persons",
                        principalColumn: "personId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personId = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_Orders_Persons_personId",
                        column: x => x.personId,
                        principalTable: "Persons",
                        principalColumn: "personId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    staffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.staffId);
                    table.ForeignKey(
                        name: "FK_Staffs_Persons_personId",
                        column: x => x.personId,
                        principalTable: "Persons",
                        principalColumn: "personId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    inventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    retailId = table.Column<int>(type: "int", nullable: false),
                    available = table.Column<int>(type: "int", nullable: true),
                    lastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.inventoryId);
                    table.ForeignKey(
                        name: "FK_Inventories_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplyings",
                columns: table => new
                {
                    supplyingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supplierId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false),
                    orderedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    arrivedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hasArrived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplyings", x => x.supplyingId);
                    table.ForeignKey(
                        name: "FK_Supplyings_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplyings_Suppliers_supplierId",
                        column: x => x.supplierId,
                        principalTable: "Suppliers",
                        principalColumn: "supplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_Orders",
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
                name: "Refunds",
                columns: table => new
                {
                    refundId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refunds", x => x.refundId);
                    table.ForeignKey(
                        name: "FK_Refunds_Orders_orderId",
                        column: x => x.orderId,
                        principalTable: "Orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Refunds_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployedAts",
                columns: table => new
                {
                    retailId = table.Column<int>(type: "int", nullable: false),
                    staffId = table.Column<int>(type: "int", nullable: false),
                    RetailChainretailId = table.Column<int>(type: "int", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employedSince = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployedAts", x => new { x.staffId, x.retailId });
                    table.ForeignKey(
                        name: "FK_EmployedAts_RetailChains_RetailChainretailId",
                        column: x => x.RetailChainretailId,
                        principalTable: "RetailChains",
                        principalColumn: "retailId");
                    table.ForeignKey(
                        name: "FK_EmployedAts_Staffs_staffId",
                        column: x => x.staffId,
                        principalTable: "Staffs",
                        principalColumn: "staffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "personId", "address", "dateOfBirth", "email", "firstName", "gender", "lastName", "phone", "status" },
                values: new object[,]
                {
                    { 1, "312, Lac Long Quan", new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3248), "nbi2271@gmail.com", "Neo", "Male", "Nguyen", "0944565607", "single" },
                    { 2, "262, Lac Long Quan", new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3251), "nbi6731@gmail.com", "Lanh", "Male", "Nguyen", "0911967483", "single" },
                    { 3, "458, Nguyen Huu Tho", new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3253), "nbi9922@gmail.com", "Bi", "Male", "Nguyen", "0817559294", "single" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "productId", "categoryId", "price", "productName" },
                values: new object[,]
                {
                    { 1, 1, 20m, "lamboghini" },
                    { 2, 2, 30m, "ferrari" },
                    { 3, 3, 40m, "lamboghini" }
                });

            migrationBuilder.InsertData(
                table: "RetailChains",
                columns: new[] { "retailId", "address", "name" },
                values: new object[,]
                {
                    { 1, "156, Duong 3/2", "Retail1" },
                    { 2, "326, Nguyen Tri Phuong", "Retail2" },
                    { 3, "221, Hoa Hao", "Retail3" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "supplierId", "name" },
                values: new object[,]
                {
                    { 1, "Supplier1" },
                    { 2, "Supplier2" },
                    { 3, "Supplier3" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "customerId", "personId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "inventoryId", "available", "lastUpdated", "productId", "retailId" },
                values: new object[,]
                {
                    { 1, 500, null, 1, 1 },
                    { 2, 500, null, 2, 2 },
                    { 3, 500, null, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "orderId", "createdAt", "personId", "subtotal", "total", "vat" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3209), 1, 200m, 220m, 20m },
                    { 2, new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3214), 2, 300m, 330m, 30m },
                    { 3, new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3215), 3, 400m, 440m, 40m }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "staffId", "personId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Supplyings",
                columns: new[] { "supplyingId", "amount", "arrivedAt", "hasArrived", "orderedAt", "productId", "supplierId" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3311), false, new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3312), 1, 1 },
                    { 2, 20, new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3313), true, new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3314), 2, 2 },
                    { 3, 30, new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3315), false, new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3316), 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "EmployedAts",
                columns: new[] { "retailId", "staffId", "RetailChainretailId", "employedSince", "role" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3187), "Manager" },
                    { 2, 2, null, new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3197), "Staff" },
                    { 3, 3, null, new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3198), "Cashier" }
                });

            migrationBuilder.InsertData(
                table: "Product_Orders",
                columns: new[] { "orderId", "productId", "countingUnit", "quantity", "total" },
                values: new object[,]
                {
                    { 1, 1, "chiec", 10, 100m },
                    { 2, 2, "chiec", 20, 200m },
                    { 3, 3, "chiec", 30, 300m }
                });

            migrationBuilder.InsertData(
                table: "Refunds",
                columns: new[] { "refundId", "createdAt", "orderId", "productId", "reason" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3281), 1, 1, "Tai t thich" },
                    { 2, new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3283), 2, 2, "Tai t thich duoc k?" },
                    { 3, new DateTime(2022, 12, 27, 20, 30, 22, 420, DateTimeKind.Local).AddTicks(3284), 3, 3, "Tai t lai thich" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_personId",
                table: "Customers",
                column: "personId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployedAts_RetailChainretailId",
                table: "EmployedAts",
                column: "RetailChainretailId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_productId",
                table: "Inventories",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_personId",
                table: "Orders",
                column: "personId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Orders_productId",
                table: "Product_Orders",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Refunds_orderId",
                table: "Refunds",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_Refunds_productId",
                table: "Refunds",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_personId",
                table: "Staffs",
                column: "personId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplyings_productId",
                table: "Supplyings",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplyings_supplierId",
                table: "Supplyings",
                column: "supplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "EmployedAts");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Product_Orders");

            migrationBuilder.DropTable(
                name: "Refunds");

            migrationBuilder.DropTable(
                name: "Supplyings");

            migrationBuilder.DropTable(
                name: "RetailChains");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
