using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockCartApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Sku = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Sku" },
                values: new object[,]
                {
                    { new Guid("a0000000-0000-0000-0000-000000000001"), "สบู่ก้อนนกแก้ว (สีเขียว)", 15m, "ITM-001" },
                    { new Guid("a0000000-0000-0000-0000-000000000002"), "ยาสีฟันคอลเกต 150g", 45m, "ITM-002" },
                    { new Guid("a0000000-0000-0000-0000-000000000003"), "แชมพูซันซิล 400ml", 129m, "ITM-003" },
                    { new Guid("a0000000-0000-0000-0000-000000000004"), "ผงซักฟอกบรีส เอกเซล 1500g", 145m, "ITM-004" },
                    { new Guid("a0000000-0000-0000-0000-000000000005"), "น้ำยาล้างจานซันไลต์ 800ml", 42m, "ITM-005" },
                    { new Guid("a0000000-0000-0000-0000-000000000006"), "กระดาษทิชชู่ Scott (แพ็ค 6 ม้วน)", 89m, "ITM-006" },
                    { new Guid("a0000000-0000-0000-0000-000000000007"), "น้ำดื่มคริสตัล 1.5 ลิตร", 15m, "ITM-007" },
                    { new Guid("a0000000-0000-0000-0000-000000000008"), "บะหมี่กึ่งสำเร็จรูป มาม่าหมูสับ", 7m, "ITM-008" },
                    { new Guid("a0000000-0000-0000-0000-000000000009"), "ปลากระป๋องสามแม่ครัว", 20m, "ITM-009" },
                    { new Guid("a0000000-0000-0000-0000-000000000010"), "สมุดโน้ตริมลวด A5", 35m, "ITM-010" },
                    { new Guid("a0000000-0000-0000-0000-000000000011"), "ปากกาลูกลื่นสีน้ำเงิน (แพ็ค 3 ด้าม)", 25m, "ITM-011" },
                    { new Guid("a0000000-0000-0000-0000-000000000012"), "ถ่านอัลคาไลน์ AA (แพ็ค 4 ก้อน)", 75m, "ITM-012" }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("b0000000-0000-0000-0000-000000000001"), new Guid("a0000000-0000-0000-0000-000000000001"), 50 },
                    { new Guid("b0000000-0000-0000-0000-000000000002"), new Guid("a0000000-0000-0000-0000-000000000002"), 30 },
                    { new Guid("b0000000-0000-0000-0000-000000000003"), new Guid("a0000000-0000-0000-0000-000000000003"), 25 },
                    { new Guid("b0000000-0000-0000-0000-000000000004"), new Guid("a0000000-0000-0000-0000-000000000004"), 20 },
                    { new Guid("b0000000-0000-0000-0000-000000000005"), new Guid("a0000000-0000-0000-0000-000000000005"), 40 },
                    { new Guid("b0000000-0000-0000-0000-000000000006"), new Guid("a0000000-0000-0000-0000-000000000006"), 100 },
                    { new Guid("b0000000-0000-0000-0000-000000000007"), new Guid("a0000000-0000-0000-0000-000000000007"), 200 },
                    { new Guid("b0000000-0000-0000-0000-000000000008"), new Guid("a0000000-0000-0000-0000-000000000008"), 150 },
                    { new Guid("b0000000-0000-0000-0000-000000000009"), new Guid("a0000000-0000-0000-0000-000000000009"), 60 },
                    { new Guid("b0000000-0000-0000-0000-000000000010"), new Guid("a0000000-0000-0000-0000-000000000010"), 15 },
                    { new Guid("b0000000-0000-0000-0000-000000000011"), new Guid("a0000000-0000-0000-0000-000000000011"), 80 },
                    { new Guid("b0000000-0000-0000-0000-000000000012"), new Guid("a0000000-0000-0000-0000-000000000012"), 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
