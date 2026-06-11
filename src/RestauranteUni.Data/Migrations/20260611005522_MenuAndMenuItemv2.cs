using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestauranteUni.Data.Migrations
{
    /// <inheritdoc />
    public partial class MenuAndMenuItemv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "menus",
                columns: new[] { "id", "active", "created_at", "name", "restaurant_id", "updated_at" },
                values: new object[] { new Guid("2f58e8cb-2936-4a18-b71f-6d8e0f9e91b0"), true, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teste", new Guid("9a88024d-2618-4e25-87f5-35217f7a7c8a"), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "menus",
                keyColumn: "id",
                keyValue: new Guid("2f58e8cb-2936-4a18-b71f-6d8e0f9e91b0"));
        }
    }
}
