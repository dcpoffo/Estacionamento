using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class CriacaoTabelaPreco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Preco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VigenciaInicial = table.Column<DateTime>(nullable: false),
                    VigenciaFinal = table.Column<DateTime>(nullable: false),
                    ValorHora = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preco", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Preco",
                columns: new[] { "Id", "ValorHora", "VigenciaFinal", "VigenciaInicial" },
                values: new object[] { 1, 3.0, new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Preco",
                columns: new[] { "Id", "ValorHora", "VigenciaFinal", "VigenciaInicial" },
                values: new object[] { 2, 5.0, new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Preco");
        }
    }
}
