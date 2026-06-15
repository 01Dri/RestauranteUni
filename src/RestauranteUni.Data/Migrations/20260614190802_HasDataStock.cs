using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestauranteUni.Data.Migrations
{
    /// <inheritdoc />
    public partial class HasDataStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "stock",
                columns: new[] { "id", "active", "created_at", "public_id", "restaurant_id", "updated_at" },
                values: new object[] { 1L, true, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("9a88024d-2618-4e25-87f5-35217f7a7c8a"), null });

            migrationBuilder.InsertData(
                table: "stock_ingredient",
                columns: new[] { "id", "active", "created_at", "name", "public_id", "quantity", "StockId", "StockId1", "unit", "updated_at" },
                values: new object[,]
                {
                    { 1L, true, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tomate", new Guid("00000000-0000-0000-0000-000000000002"), 100m, 1L, null, 3, null },
                    { 2L, true, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alface", new Guid("00000000-0000-0000-0000-000000000003"), 50m, 1L, null, 3, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "stock_ingredient",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "stock_ingredient",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "stock",
                keyColumn: "id",
                keyValue: 1L);
        }
    }
}
