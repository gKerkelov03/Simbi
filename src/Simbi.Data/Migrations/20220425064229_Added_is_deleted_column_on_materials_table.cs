using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simbi.Data.Migrations
{
    public partial class Added_is_deleted_column_on_materials_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Orders_OrderEntityId",
                table: "Purchases");

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialEntityId",
                table: "Purchases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Materials",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_MaterialEntityId",
                table: "Purchases",
                column: "MaterialEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Materials_MaterialEntityId",
                table: "Purchases",
                column: "MaterialEntityId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Orders_OrderEntityId",
                table: "Purchases",
                column: "OrderEntityId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Materials_MaterialEntityId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Orders_OrderEntityId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_MaterialEntityId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "MaterialEntityId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Materials");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Orders_OrderEntityId",
                table: "Purchases",
                column: "OrderEntityId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
