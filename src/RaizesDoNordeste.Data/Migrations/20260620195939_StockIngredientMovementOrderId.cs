using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaizesDoNordeste.Data.Migrations
{
    /// <inheritdoc />
    public partial class StockIngredientMovementOrderId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stock_ingredient_movement_orders_OrderId",
                table: "stock_ingredient_movement");

            migrationBuilder.DropColumn(
                name: "OrderPublicId",
                table: "stock_ingredient_movement");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "stock_ingredient_movement",
                newName: "order_id");

            migrationBuilder.RenameIndex(
                name: "IX_stock_ingredient_movement_OrderId",
                table: "stock_ingredient_movement",
                newName: "IX_stock_ingredient_movement_order_id");

            migrationBuilder.AddForeignKey(
                name: "FK_stock_ingredient_movement_orders_order_id",
                table: "stock_ingredient_movement",
                column: "order_id",
                principalTable: "orders",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stock_ingredient_movement_orders_order_id",
                table: "stock_ingredient_movement");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "stock_ingredient_movement",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_stock_ingredient_movement_order_id",
                table: "stock_ingredient_movement",
                newName: "IX_stock_ingredient_movement_OrderId");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderPublicId",
                table: "stock_ingredient_movement",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_stock_ingredient_movement_orders_OrderId",
                table: "stock_ingredient_movement",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "id");
        }
    }
}

