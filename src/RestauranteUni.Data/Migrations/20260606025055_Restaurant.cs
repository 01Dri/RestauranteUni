using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestauranteUni.Data.Migrations
{
    /// <inheritdoc />
    public partial class Restaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "restaurants",
                columns: new[] { "id", "active", "cnpj", "created_at", "description", "email", "name", "phone", "updated_at", "address_city", "address_complement", "address_district", "address_number", "address_state", "address_street", "address_zip_code" },
                values: new object[,]
                {
                    { new Guid("9a88024d-2618-4e25-87f5-35217f7a7c8a"), true, "12345678000195", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Restaurante principal do campus com refeicoes acessiveis para estudantes.", "ru@restauranteuni.com", "Restaurante Universitario", "1133334444", null, "Sao Paulo", "Bloco A", "Centro", "1000", "SP", "Avenida Universitaria", "01001000" },
                    { new Guid("be0b1f01-0d0f-43e6-9575-b1e117ad62cb"), true, "98765432000198", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Espaco com pratos executivos e opcoes vegetarianas.", "bistro@restauranteuni.com", "Bistro do Campus", "1130302020", null, "Sao Paulo", "Predio 2", "Campus Norte", "45", "SP", "Alameda das Ciencias", "01003000" },
                    { new Guid("f02884ad-1725-4fcb-9bb6-cbf0b8f5fef6"), true, "11222333000181", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Cantina com lanches, bebidas e opcoes rapidas entre as aulas.", "cantina@restauranteuni.com", "Cantina Central", "11988887777", null, "Sao Paulo", "Praca de alimentacao", "Vila Academica", "250", "SP", "Rua dos Estudantes", "01002000" }
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "restaurants");
        }
    }
}
