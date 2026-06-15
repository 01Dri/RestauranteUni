using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteUni.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_menu_item_ingredient_menu_item_MenuItemId1",
                table: "menu_item_ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_stock_ingredient_stock_StockId1",
                table: "stock_ingredient");

            migrationBuilder.DropIndex(
                name: "IX_stock_ingredient_StockId1",
                table: "stock_ingredient");

            migrationBuilder.DropIndex(
                name: "IX_menu_item_ingredient_MenuItemId1",
                table: "menu_item_ingredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "StockId1",
                table: "stock_ingredient");

            migrationBuilder.DropColumn(
                name: "MenuItemId1",
                table: "menu_item_ingredient");

            migrationBuilder.RenameTable(
                name: "Ingredient",
                newName: "Ingredients");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredient_public_id",
                table: "Ingredients",
                newName: "IX_Ingredients_public_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.RenameTable(
                name: "Ingredients",
                newName: "Ingredient");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_public_id",
                table: "Ingredient",
                newName: "IX_Ingredient_public_id");

            migrationBuilder.AddColumn<long>(
                name: "StockId1",
                table: "stock_ingredient",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MenuItemId1",
                table: "menu_item_ingredient",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                column: "id");

            migrationBuilder.UpdateData(
                table: "menu_item_ingredient",
                keyColumn: "id",
                keyValue: 1L,
                column: "MenuItemId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "menu_item_ingredient",
                keyColumn: "id",
                keyValue: 2L,
                column: "MenuItemId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "stock_ingredient",
                keyColumn: "id",
                keyValue: 1L,
                column: "StockId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "stock_ingredient",
                keyColumn: "id",
                keyValue: 2L,
                column: "StockId1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_stock_ingredient_StockId1",
                table: "stock_ingredient",
                column: "StockId1");

            migrationBuilder.CreateIndex(
                name: "IX_menu_item_ingredient_MenuItemId1",
                table: "menu_item_ingredient",
                column: "MenuItemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_menu_item_ingredient_menu_item_MenuItemId1",
                table: "menu_item_ingredient",
                column: "MenuItemId1",
                principalTable: "menu_item",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_stock_ingredient_stock_StockId1",
                table: "stock_ingredient",
                column: "StockId1",
                principalTable: "stock",
                principalColumn: "id");
        }
    }
}
