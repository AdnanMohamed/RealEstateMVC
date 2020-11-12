using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Properties_PropertyId",
                table: "Deals");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Customers_CustomerId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Properties",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Deals_PropertyId",
                table: "Deals");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Properties",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertyId",
                table: "Properties",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PropertyId",
                table: "Deals",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Properties",
                table: "Properties",
                columns: new[] { "Id", "CustomerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyId",
                table: "Properties",
                column: "PropertyId",
                unique: true,
                filter: "[PropertyId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Customers_CustomerId",
                table: "Properties",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Deals_PropertyId",
                table: "Properties",
                column: "PropertyId",
                principalTable: "Deals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Customers_CustomerId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Deals_PropertyId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Properties",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_PropertyId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Properties");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Properties",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PropertyId",
                table: "Deals",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Properties",
                table: "Properties",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_PropertyId",
                table: "Deals",
                column: "PropertyId",
                unique: true,
                filter: "[PropertyId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Properties_PropertyId",
                table: "Deals",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Customers_CustomerId",
                table: "Properties",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
