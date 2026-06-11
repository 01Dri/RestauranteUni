using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestauranteUni.Data.Migrations
{
    /// <inheritdoc />
    public partial class MenuAndMenuItemV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "menus",
                keyColumn: "id",
                keyValue: new Guid("2f58e8cb-2936-4a18-b71f-6d8e0f9e91b0"));

            migrationBuilder.InsertData(
                table: "menus",
                columns: new[] { "id", "active", "created_at", "name", "restaurant_id", "updated_at" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), true, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teste", new Guid("9a88024d-2618-4e25-87f5-35217f7a7c8a"), null });

            migrationBuilder.InsertData(
                table: "menu_items",
                columns: new[] { "id", "active", "created_at", "description", "display_order", "image_url", "is_available", "is_featured", "menu_id", "preparation_time_in_minutes", "price", "title", "updated_at" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222222"), true, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hambúrguer artesanal com queijo e salada", 1, "/images/xburger.jpg", true, true, new Guid("11111111-1111-1111-1111-111111111111"), 15, 29.90m, "X-Burger", null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), true, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pizza tradicional de calabresa", 2, "/images/calabresa.jpg", true, true, new Guid("11111111-1111-1111-1111-111111111111"), 25, 59.90m, "Pizza Calabresa", null }
                });

            migrationBuilder.InsertData(
                table: "menu_items",
                columns: new[] { "id", "active", "created_at", "description", "display_order", "image_url", "is_available", "menu_id", "preparation_time_in_minutes", "price", "title", "updated_at" },
                values: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), true, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refrigerante lata", 3, "/images/coca350.jpg", true, new Guid("11111111-1111-1111-1111-111111111111"), 1, 6.50m, "Coca-Cola 350ml", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "menus",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.InsertData(
                table: "menus",
                columns: new[] { "id", "active", "created_at", "name", "restaurant_id", "updated_at" },
                values: new object[] { new Guid("2f58e8cb-2936-4a18-b71f-6d8e0f9e91b0"), true, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teste", new Guid("9a88024d-2618-4e25-87f5-35217f7a7c8a"), null });
        }
    }
}
