using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierCode = table.Column<string>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierCode);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductCode = table.Column<string>(nullable: false),
                    BomCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    SupplierCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductCode);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierCode",
                        column: x => x.SupplierCode,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Boms",
                columns: table => new
                {
                    BomCode = table.Column<string>(nullable: false),
                    ParentProductCode = table.Column<string>(nullable: true),
                    ProductCode = table.Column<string>(nullable: false),
                    Quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boms", x => x.BomCode);
                    table.ForeignKey(
                        name: "FK_Boms_Products_ParentProductCode",
                        column: x => x.ParentProductCode,
                        principalTable: "Products",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Boms_Products_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "Products",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boms_ParentProductCode",
                table: "Boms",
                column: "ParentProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_Boms_ProductCode",
                table: "Boms",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BomCode",
                table: "Products",
                column: "BomCode");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierCode",
                table: "Products",
                column: "SupplierCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Boms_BomCode",
                table: "Products",
                column: "BomCode",
                principalTable: "Boms",
                principalColumn: "BomCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boms_Products_ParentProductCode",
                table: "Boms");

            migrationBuilder.DropForeignKey(
                name: "FK_Boms_Products_ProductCode",
                table: "Boms");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Boms");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
