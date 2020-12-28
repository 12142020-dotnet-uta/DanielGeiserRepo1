using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project_0.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Customer_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    favstore = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Customer_Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    storeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    totalSales = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemsAtStore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: true),
                    qty = table.Column<int>(type: "int", nullable: false),
                    sale = table.Column<double>(type: "float", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsAtStore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsAtStore_products_productId",
                        column: x => x.productId,
                        principalTable: "products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemsAtStore_stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    orderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stroeLocationId = table.Column<int>(type: "int", nullable: false),
                    Customer_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    total = table.Column<double>(type: "float", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.orderID);
                    table.ForeignKey(
                        name: "FK_orders_customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "customers",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_stores_stroeLocationId",
                        column: x => x.stroeLocationId,
                        principalTable: "stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderedItems",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderedItems", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_orderedItems_ItemsAtStore_itemId",
                        column: x => x.itemId,
                        principalTable: "ItemsAtStore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemsAtStore_productId",
                table: "ItemsAtStore",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsAtStore_StoreId",
                table: "ItemsAtStore",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_orderedItems_itemId",
                table: "orderedItems",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_Customer_Id",
                table: "orders",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_stroeLocationId",
                table: "orders",
                column: "stroeLocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderedItems");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "ItemsAtStore");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "stores");
        }
    }
}
