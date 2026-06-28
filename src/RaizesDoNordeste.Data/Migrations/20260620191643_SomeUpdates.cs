using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaizesDoNordeste.Data.Migrations
{
    /// <inheritdoc />
    public partial class SomeUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "order_items");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "menu_item_ingredient",
                newName: "quantity_use_to_order");

            migrationBuilder.AddColumn<long>(
                name: "OrderId",
                table: "stock_ingredient_movement",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderPublicId",
                table: "stock_ingredient_movement",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_stock_ingredient_movement_OrderId",
                table: "stock_ingredient_movement",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_stock_ingredient_movement_orders_OrderId",
                table: "stock_ingredient_movement",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stock_ingredient_movement_orders_OrderId",
                table: "stock_ingredient_movement");

            migrationBuilder.DropIndex(
                name: "IX_stock_ingredient_movement_OrderId",
                table: "stock_ingredient_movement");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "stock_ingredient_movement");

            migrationBuilder.DropColumn(
                name: "OrderPublicId",
                table: "stock_ingredient_movement");

            migrationBuilder.RenameColumn(
                name: "quantity_use_to_order",
                table: "menu_item_ingredient",
                newName: "quantity");

            migrationBuilder.AddColumn<decimal>(
                name: "quantity",
                table: "order_items",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "order_items",
                keyColumn: "id",
                keyValue: 1L,
                column: "quantity",
                value: 2m);

            migrationBuilder.UpdateData(
                table: "order_items",
                keyColumn: "id",
                keyValue: 2L,
                column: "quantity",
                value: 1m);
        }
    }
}

