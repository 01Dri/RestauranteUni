using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RaizesDoNordeste.Data.Migrations
{
    /// <inheritdoc />
    public partial class HasDataMenuItemIngredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_menu_item_ingredient_menu_items_MenuItemId1",
                table: "menu_item_ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_menu_item_ingredient_menu_items_menu_item_id",
                table: "menu_item_ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_menu_items_menus_menu_id",
                table: "menu_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_menu_items",
                table: "menu_items");

            migrationBuilder.RenameTable(
                name: "menu_items",
                newName: "menu_item");

            migrationBuilder.RenameIndex(
                name: "IX_menu_items_public_id",
                table: "menu_item",
                newName: "IX_menu_item_public_id");

            migrationBuilder.RenameIndex(
                name: "IX_menu_items_menu_id_display_order",
                table: "menu_item",
                newName: "IX_menu_item_menu_id_display_order");

            migrationBuilder.RenameIndex(
                name: "IX_menu_items_menu_id",
                table: "menu_item",
                newName: "IX_menu_item_menu_id");

            migrationBuilder.RenameIndex(
                name: "IX_menu_items_is_featured",
                table: "menu_item",
                newName: "IX_menu_item_is_featured");

            migrationBuilder.RenameIndex(
                name: "IX_menu_items_is_available",
                table: "menu_item",
                newName: "IX_menu_item_is_available");

            migrationBuilder.AddPrimaryKey(
                name: "PK_menu_item",
                table: "menu_item",
                column: "id");

            migrationBuilder.InsertData(
                table: "menu_item_ingredient",
                columns: new[] { "id", "menu_item_id", "MenuItemId1", "quantity", "stock_ingredient_id" },
                values: new object[,]
                {
                    { 1L, 1L, null, 0.5m, 1L },
                    { 2L, 1L, null, 0.2m, 2L }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_menu_item_menus_menu_id",
                table: "menu_item",
                column: "menu_id",
                principalTable: "menus",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_menu_item_ingredient_menu_item_MenuItemId1",
                table: "menu_item_ingredient",
                column: "MenuItemId1",
                principalTable: "menu_item",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_menu_item_ingredient_menu_item_menu_item_id",
                table: "menu_item_ingredient",
                column: "menu_item_id",
                principalTable: "menu_item",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_menu_item_menus_menu_id",
                table: "menu_item");

            migrationBuilder.DropForeignKey(
                name: "FK_menu_item_ingredient_menu_item_MenuItemId1",
                table: "menu_item_ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_menu_item_ingredient_menu_item_menu_item_id",
                table: "menu_item_ingredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_menu_item",
                table: "menu_item");

            migrationBuilder.DeleteData(
                table: "menu_item_ingredient",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "menu_item_ingredient",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.RenameTable(
                name: "menu_item",
                newName: "menu_items");

            migrationBuilder.RenameIndex(
                name: "IX_menu_item_public_id",
                table: "menu_items",
                newName: "IX_menu_items_public_id");

            migrationBuilder.RenameIndex(
                name: "IX_menu_item_menu_id_display_order",
                table: "menu_items",
                newName: "IX_menu_items_menu_id_display_order");

            migrationBuilder.RenameIndex(
                name: "IX_menu_item_menu_id",
                table: "menu_items",
                newName: "IX_menu_items_menu_id");

            migrationBuilder.RenameIndex(
                name: "IX_menu_item_is_featured",
                table: "menu_items",
                newName: "IX_menu_items_is_featured");

            migrationBuilder.RenameIndex(
                name: "IX_menu_item_is_available",
                table: "menu_items",
                newName: "IX_menu_items_is_available");

            migrationBuilder.AddPrimaryKey(
                name: "PK_menu_items",
                table: "menu_items",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_menu_item_ingredient_menu_items_MenuItemId1",
                table: "menu_item_ingredient",
                column: "MenuItemId1",
                principalTable: "menu_items",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_menu_item_ingredient_menu_items_menu_item_id",
                table: "menu_item_ingredient",
                column: "menu_item_id",
                principalTable: "menu_items",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_menu_items_menus_menu_id",
                table: "menu_items",
                column: "menu_id",
                principalTable: "menus",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

