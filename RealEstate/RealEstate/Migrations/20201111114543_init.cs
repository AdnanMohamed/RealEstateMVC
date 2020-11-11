using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salespeople",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salespeople", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PropertyType = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    LocationURL = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SalespersonId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true),
                    PropertyId = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Commission = table.Column<decimal>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deals_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deals_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deals_Salespeople_SalespersonId",
                        column: x => x.SalespersonId,
                        principalTable: "Salespeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deals_CustomerId",
                table: "Deals",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_PropertyId",
                table: "Deals",
                column: "PropertyId",
                unique: true,
                filter: "[PropertyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_SalespersonId",
                table: "Deals",
                column: "SalespersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CustomerId",
                table: "Properties",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deals");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Salespeople");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
