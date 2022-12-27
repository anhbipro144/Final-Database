using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final.Migrations
{
    /// <inheritdoc />
    public partial class Models2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product_Orders",
                table: "Product_Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployedAts",
                table: "EmployedAts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Product_Orders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EmployedAts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Supplyings",
                newName: "supplyingId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Suppliers",
                newName: "supplierId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Staffs",
                newName: "staffId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RetailChains",
                newName: "retailId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Refunds",
                newName: "refundId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Persons",
                newName: "personId");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Orders",
                newName: "personId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "orderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Inventories",
                newName: "inventoryId");

            migrationBuilder.RenameColumn(
                name: "employeeId",
                table: "EmployedAts",
                newName: "staffId");

            migrationBuilder.AddColumn<string>(
                name: "productId1",
                table: "Supplyings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "productId1",
                table: "Refunds",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "productId1",
                table: "Product_Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RetailChainretailId",
                table: "Inventories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "productId1",
                table: "Inventories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RetailChainretailId",
                table: "EmployedAts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customerId);
                    table.ForeignKey(
                        name: "FK_Customers_Persons_personId",
                        column: x => x.personId,
                        principalTable: "Persons",
                        principalColumn: "personId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supplyings_productId1",
                table: "Supplyings",
                column: "productId1");

            migrationBuilder.CreateIndex(
                name: "IX_Supplyings_supplierId",
                table: "Supplyings",
                column: "supplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_personId",
                table: "Staffs",
                column: "personId");

            migrationBuilder.CreateIndex(
                name: "IX_Refunds_orderId",
                table: "Refunds",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_Refunds_productId1",
                table: "Refunds",
                column: "productId1");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Orders_orderId",
                table: "Product_Orders",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Orders_productId1",
                table: "Product_Orders",
                column: "productId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_personId",
                table: "Orders",
                column: "personId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_productId1",
                table: "Inventories",
                column: "productId1");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_RetailChainretailId",
                table: "Inventories",
                column: "RetailChainretailId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployedAts_RetailChainretailId",
                table: "EmployedAts",
                column: "RetailChainretailId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployedAts_staffId",
                table: "EmployedAts",
                column: "staffId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_personId",
                table: "Customers",
                column: "personId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployedAts_RetailChains_RetailChainretailId",
                table: "EmployedAts",
                column: "RetailChainretailId",
                principalTable: "RetailChains",
                principalColumn: "retailId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployedAts_Staffs_staffId",
                table: "EmployedAts",
                column: "staffId",
                principalTable: "Staffs",
                principalColumn: "staffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Product_productId1",
                table: "Inventories",
                column: "productId1",
                principalTable: "Product",
                principalColumn: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_RetailChains_RetailChainretailId",
                table: "Inventories",
                column: "RetailChainretailId",
                principalTable: "RetailChains",
                principalColumn: "retailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Persons_personId",
                table: "Orders",
                column: "personId",
                principalTable: "Persons",
                principalColumn: "personId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Orders_Orders_orderId",
                table: "Product_Orders",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Orders_Product_productId1",
                table: "Product_Orders",
                column: "productId1",
                principalTable: "Product",
                principalColumn: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_Refunds_Orders_orderId",
                table: "Refunds",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Refunds_Product_productId1",
                table: "Refunds",
                column: "productId1",
                principalTable: "Product",
                principalColumn: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Persons_personId",
                table: "Staffs",
                column: "personId",
                principalTable: "Persons",
                principalColumn: "personId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplyings_Product_productId1",
                table: "Supplyings",
                column: "productId1",
                principalTable: "Product",
                principalColumn: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplyings_Suppliers_supplierId",
                table: "Supplyings",
                column: "supplierId",
                principalTable: "Suppliers",
                principalColumn: "supplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployedAts_RetailChains_RetailChainretailId",
                table: "EmployedAts");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployedAts_Staffs_staffId",
                table: "EmployedAts");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Product_productId1",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_RetailChains_RetailChainretailId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Persons_personId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Orders_Orders_orderId",
                table: "Product_Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Orders_Product_productId1",
                table: "Product_Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Refunds_Orders_orderId",
                table: "Refunds");

            migrationBuilder.DropForeignKey(
                name: "FK_Refunds_Product_productId1",
                table: "Refunds");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Persons_personId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplyings_Product_productId1",
                table: "Supplyings");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplyings_Suppliers_supplierId",
                table: "Supplyings");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Supplyings_productId1",
                table: "Supplyings");

            migrationBuilder.DropIndex(
                name: "IX_Supplyings_supplierId",
                table: "Supplyings");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_personId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Refunds_orderId",
                table: "Refunds");

            migrationBuilder.DropIndex(
                name: "IX_Refunds_productId1",
                table: "Refunds");

            migrationBuilder.DropIndex(
                name: "IX_Product_Orders_orderId",
                table: "Product_Orders");

            migrationBuilder.DropIndex(
                name: "IX_Product_Orders_productId1",
                table: "Product_Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_personId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_productId1",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_RetailChainretailId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_EmployedAts_RetailChainretailId",
                table: "EmployedAts");

            migrationBuilder.DropIndex(
                name: "IX_EmployedAts_staffId",
                table: "EmployedAts");

            migrationBuilder.DropColumn(
                name: "productId1",
                table: "Supplyings");

            migrationBuilder.DropColumn(
                name: "productId1",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "productId1",
                table: "Product_Orders");

            migrationBuilder.DropColumn(
                name: "RetailChainretailId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "productId1",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "RetailChainretailId",
                table: "EmployedAts");

            migrationBuilder.RenameColumn(
                name: "supplyingId",
                table: "Supplyings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "supplierId",
                table: "Suppliers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "staffId",
                table: "Staffs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "retailId",
                table: "RetailChains",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "refundId",
                table: "Refunds",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "personId",
                table: "Persons",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "personId",
                table: "Orders",
                newName: "customerId");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "inventoryId",
                table: "Inventories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "staffId",
                table: "EmployedAts",
                newName: "employeeId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Product_Orders",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EmployedAts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product_Orders",
                table: "Product_Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployedAts",
                table: "EmployedAts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }
    }
}
