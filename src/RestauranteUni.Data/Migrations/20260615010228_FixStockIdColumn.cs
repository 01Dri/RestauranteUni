using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteUni.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixStockIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stock_ingredient_stock_StockId",
                table: "stock_ingredient");

            migrationBuilder.RenameColumn(
                name: "StockId",
                table: "stock_ingredient",
                newName: "stock_id");

            migrationBuilder.RenameIndex(
                name: "IX_stock_ingredient_StockId",
                table: "stock_ingredient",
                newName: "IX_stock_ingredient_stock_id");

            migrationBuilder.AlterColumn<long>(
                name: "stock_id",
                table: "stock_ingredient",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_stock_ingredient_stock_stock_id",
                table: "stock_ingredient",
                column: "stock_id",
                principalTable: "stock",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stock_ingredient_stock_stock_id",
                table: "stock_ingredient");

            migrationBuilder.RenameColumn(
                name: "stock_id",
                table: "stock_ingredient",
                newName: "StockId");

            migrationBuilder.RenameIndex(
                name: "IX_stock_ingredient_stock_id",
                table: "stock_ingredient",
                newName: "IX_stock_ingredient_StockId");

            migrationBuilder.AlterColumn<long>(
                name: "StockId",
                table: "stock_ingredient",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_stock_ingredient_stock_StockId",
                table: "stock_ingredient",
                column: "StockId",
                principalTable: "stock",
                principalColumn: "id");
        }
    }
}
