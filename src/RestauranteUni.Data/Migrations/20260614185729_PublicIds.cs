using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestauranteUni.Data.Migrations
{
    /// <inheritdoc />
    public partial class PublicIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    email = table.Column<string>(type: "TEXT", maxLength: 254, nullable: false),
                    password = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    active = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    public_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    unit = table.Column<int>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    active = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "restaurants",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    phone = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    address_street = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    address_number = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    address_district = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    address_city = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    address_state = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false),
                    address_zip_code = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    address_complement = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    email = table.Column<string>(type: "TEXT", maxLength: 254, nullable: false),
                    cnpj = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    active = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "menus",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    public_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    restaurant_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    active = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menus", x => x.id);
                    table.ForeignKey(
                        name: "FK_menus_restaurants_restaurant_id",
                        column: x => x.restaurant_id,
                        principalTable: "restaurants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stock",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    public_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    restaurant_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    active = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock", x => x.id);
                    table.ForeignKey(
                        name: "FK_stock_restaurants_restaurant_id",
                        column: x => x.restaurant_id,
                        principalTable: "restaurants",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "role_accounts",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    account_id = table.Column<long>(type: "INTEGER", nullable: false),
                    role_id = table.Column<int>(type: "INTEGER", nullable: false),
                    role_status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_accounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_role_accounts_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_role_accounts_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "menu_items",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    public_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    price = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    image_url = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    is_available = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    display_order = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    preparation_time_in_minutes = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    is_featured = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    menu_id = table.Column<long>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    active = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_menu_items_menus_menu_id",
                        column: x => x.menu_id,
                        principalTable: "menus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stock_ingredient",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    public_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    unit = table.Column<int>(type: "INTEGER", nullable: false),
                    quantity = table.Column<decimal>(type: "TEXT", nullable: false),
                    StockId = table.Column<long>(type: "INTEGER", nullable: true),
                    StockId1 = table.Column<long>(type: "INTEGER", nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    active = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock_ingredient", x => x.id);
                    table.ForeignKey(
                        name: "FK_stock_ingredient_stock_StockId",
                        column: x => x.StockId,
                        principalTable: "stock",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_stock_ingredient_stock_StockId1",
                        column: x => x.StockId1,
                        principalTable: "stock",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "menu_item_ingredient",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    menu_item_id = table.Column<long>(type: "INTEGER", nullable: true),
                    stock_ingredient_id = table.Column<long>(type: "INTEGER", nullable: true),
                    quantity = table.Column<decimal>(type: "TEXT", nullable: false),
                    MenuItemId1 = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu_item_ingredient", x => x.id);
                    table.ForeignKey(
                        name: "FK_menu_item_ingredient_menu_items_MenuItemId1",
                        column: x => x.MenuItemId1,
                        principalTable: "menu_items",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_menu_item_ingredient_menu_items_menu_item_id",
                        column: x => x.menu_item_id,
                        principalTable: "menu_items",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_menu_item_ingredient_stock_ingredient_stock_ingredient_id",
                        column: x => x.stock_ingredient_id,
                        principalTable: "stock_ingredient",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "restaurants",
                columns: new[] { "id", "active", "cnpj", "created_at", "description", "email", "name", "phone", "updated_at", "address_city", "address_complement", "address_district", "address_number", "address_state", "address_street", "address_zip_code" },
                values: new object[,]
                {
                    { new Guid("9a88024d-2618-4e25-87f5-35217f7a7c8a"), true, "12345678000195", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Restaurante principal do campus com refeicoes acessiveis para estudantes.", "ru@restauranteuni.com", "Restaurante Universitario", "1133334444", null, "Sao Paulo", "Bloco A", "Centro", "1000", "SP", "Avenida Universitaria", "01001000" },
                    { new Guid("be0b1f01-0d0f-43e6-9575-b1e117ad62cb"), true, "98765432000198", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Espaco com pratos executivos e opcoes vegetarianas.", "bistro@restauranteuni.com", "Bistro do Campus", "1130302020", null, "Sao Paulo", "Predio 2", "Campus Norte", "45", "SP", "Alameda das Ciencias", "01003000" },
                    { new Guid("f02884ad-1725-4fcb-9bb6-cbf0b8f5fef6"), true, "11222333000181", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Cantina com lanches, bebidas e opcoes rapidas entre as aulas.", "cantina@restauranteuni.com", "Cantina Central", "11988887777", null, "Sao Paulo", "Praca de alimentacao", "Vila Academica", "250", "SP", "Rua dos Estudantes", "01002000" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 0, "Customer" },
                    { 1, "Manager" },
                    { 2, "Admin" },
                    { 3, "Professional" },
                    { 4, "Owner" }
                });

            migrationBuilder.InsertData(
                table: "menus",
                columns: new[] { "id", "active", "created_at", "name", "public_id", "restaurant_id", "updated_at" },
                values: new object[] { 1L, true, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teste", new Guid("9a88024d-2618-4e25-87f5-35217f7a7c8b"), new Guid("9a88024d-2618-4e25-87f5-35217f7a7c8a"), null });

            migrationBuilder.InsertData(
                table: "menu_items",
                columns: new[] { "id", "active", "created_at", "description", "display_order", "image_url", "is_available", "is_featured", "menu_id", "preparation_time_in_minutes", "price", "public_id", "title", "updated_at" },
                values: new object[,]
                {
                    { 1L, true, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hambúrguer artesanal com queijo e salada", 1, "/images/xburger.jpg", true, true, 1L, 15, 29.90m, new Guid("9a88024d-2618-4e25-87f5-35217f7a7c9b"), "X-Burger", null },
                    { 2L, true, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pizza tradicional de calabresa", 2, "/images/calabresa.jpg", true, true, 1L, 25, 59.90m, new Guid("2a88024d-2618-4e25-87f5-35217f7a7c9b"), "Pizza Calabresa", null }
                });

            migrationBuilder.InsertData(
                table: "menu_items",
                columns: new[] { "id", "active", "created_at", "description", "display_order", "image_url", "is_available", "menu_id", "preparation_time_in_minutes", "price", "public_id", "title", "updated_at" },
                values: new object[] { 3L, true, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refrigerante lata", 3, "/images/coca350.jpg", true, 1L, 1, 6.50m, new Guid("7a88024d-2618-4e25-87f5-35217f7a7c9b"), "Coca-Cola 350ml", null });

            migrationBuilder.CreateIndex(
                name: "ix_accounts_email",
                table: "accounts",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_public_id",
                table: "Ingredient",
                column: "public_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menu_item_ingredient_menu_item_id",
                table: "menu_item_ingredient",
                column: "menu_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_menu_item_ingredient_MenuItemId1",
                table: "menu_item_ingredient",
                column: "MenuItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_menu_item_ingredient_stock_ingredient_id",
                table: "menu_item_ingredient",
                column: "stock_ingredient_id");

            migrationBuilder.CreateIndex(
                name: "IX_menu_items_is_available",
                table: "menu_items",
                column: "is_available");

            migrationBuilder.CreateIndex(
                name: "IX_menu_items_is_featured",
                table: "menu_items",
                column: "is_featured");

            migrationBuilder.CreateIndex(
                name: "IX_menu_items_menu_id",
                table: "menu_items",
                column: "menu_id");

            migrationBuilder.CreateIndex(
                name: "IX_menu_items_menu_id_display_order",
                table: "menu_items",
                columns: new[] { "menu_id", "display_order" });

            migrationBuilder.CreateIndex(
                name: "IX_menu_items_public_id",
                table: "menu_items",
                column: "public_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menus_public_id",
                table: "menus",
                column: "public_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menus_restaurant_id",
                table: "menus",
                column: "restaurant_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_restaurants_cnpj",
                table: "restaurants",
                column: "cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_restaurants_email",
                table: "restaurants",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_role_accounts_account_id",
                table: "role_accounts",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_role_accounts_role_id",
                table: "role_accounts",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_roles_type",
                table: "roles",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_stock_public_id",
                table: "stock",
                column: "public_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_stock_restaurant_id",
                table: "stock",
                column: "restaurant_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_stock_ingredient_public_id",
                table: "stock_ingredient",
                column: "public_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_stock_ingredient_StockId",
                table: "stock_ingredient",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_stock_ingredient_StockId1",
                table: "stock_ingredient",
                column: "StockId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "menu_item_ingredient");

            migrationBuilder.DropTable(
                name: "role_accounts");

            migrationBuilder.DropTable(
                name: "menu_items");

            migrationBuilder.DropTable(
                name: "stock_ingredient");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "menus");

            migrationBuilder.DropTable(
                name: "stock");

            migrationBuilder.DropTable(
                name: "restaurants");
        }
    }
}
