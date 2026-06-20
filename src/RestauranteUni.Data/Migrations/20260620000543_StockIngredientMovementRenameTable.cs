using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteUni.Data.Migrations
{
    /// <inheritdoc />
    public partial class StockIngredientMovementRenameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stock_movement_stock_ingredient_stock_ingredient_id",
                table: "stock_movement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stock_movement",
                table: "stock_movement");

            migrationBuilder.RenameTable(
                name: "stock_movement",
                newName: "stock_ingredient_movement");

            migrationBuilder.RenameIndex(
                name: "IX_stock_movement_stock_ingredient_id",
                table: "stock_ingredient_movement",
                newName: "IX_stock_ingredient_movement_stock_ingredient_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_stock_ingredient_movement",
                table: "stock_ingredient_movement",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_stock_ingredient_movement_stock_ingredient_stock_ingredient_id",
                table: "stock_ingredient_movement",
                column: "stock_ingredient_id",
                principalTable: "stock_ingredient",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stock_ingredient_movement_stock_ingredient_stock_ingredient_id",
                table: "stock_ingredient_movement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stock_ingredient_movement",
                table: "stock_ingredient_movement");

            migrationBuilder.RenameTable(
                name: "stock_ingredient_movement",
                newName: "stock_movement");

            migrationBuilder.RenameIndex(
                name: "IX_stock_ingredient_movement_stock_ingredient_id",
                table: "stock_movement",
                newName: "IX_stock_movement_stock_ingredient_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_stock_movement",
                table: "stock_movement",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_stock_movement_stock_ingredient_stock_ingredient_id",
                table: "stock_movement",
                column: "stock_ingredient_id",
                principalTable: "stock_ingredient",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
