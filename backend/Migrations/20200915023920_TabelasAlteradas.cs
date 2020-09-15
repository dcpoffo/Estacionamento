using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class TabelasAlteradas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TabelaPreco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VigenciaInicial = table.Column<DateTime>(nullable: false),
                    VigenciaFinal = table.Column<DateTime>(nullable: false),
                    ValorHora = table.Column<double>(nullable: false),
                    ValorHoraAdicional = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaPreco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Placa = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    Cor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estacionamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Entrada = table.Column<DateTime>(nullable: false),
                    Saida = table.Column<DateTime>(nullable: false),
                    ValorTotal = table.Column<double>(nullable: false),
                    TabelaPrecoId = table.Column<int>(nullable: false),
                    VeiculoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estacionamento_TabelaPreco_TabelaPrecoId",
                        column: x => x.TabelaPrecoId,
                        principalTable: "TabelaPreco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estacionamento_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TabelaPreco",
                columns: new[] { "Id", "ValorHora", "ValorHoraAdicional", "VigenciaFinal", "VigenciaInicial" },
                values: new object[,]
                {
                    { 1, 3.0, 1.5, new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 5.0, 2.0, new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Veiculo",
                columns: new[] { "Id", "Cor", "Marca", "Modelo", "Placa" },
                values: new object[,]
                {
                    { 1, "Azul", "Ford", "New Fiesta", "AAA-1234" },
                    { 2, "Prata", "Chevrolet", "Onix", "BBB-1234" },
                    { 3, "Vermelho", "Fiat", "Uno", "CCC-1234" }
                });

            migrationBuilder.InsertData(
                table: "Estacionamento",
                columns: new[] { "Id", "Entrada", "Saida", "TabelaPrecoId", "ValorTotal", "VeiculoId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 9, 14, 23, 39, 20, 457, DateTimeKind.Local).AddTicks(7009), new DateTime(2020, 9, 14, 23, 49, 20, 459, DateTimeKind.Local).AddTicks(1452), 1, 2.0, 1 },
                    { 2, new DateTime(2020, 9, 14, 23, 39, 20, 459, DateTimeKind.Local).AddTicks(6299), new DateTime(2020, 9, 15, 0, 14, 20, 459, DateTimeKind.Local).AddTicks(6311), 2, 2.0, 1 },
                    { 3, new DateTime(2020, 9, 14, 23, 39, 20, 459, DateTimeKind.Local).AddTicks(6475), new DateTime(2020, 9, 15, 2, 39, 20, 459, DateTimeKind.Local).AddTicks(6478), 1, 2.0, 2 },
                    { 4, new DateTime(2020, 9, 14, 23, 39, 20, 459, DateTimeKind.Local).AddTicks(6519), new DateTime(2020, 9, 15, 1, 39, 20, 459, DateTimeKind.Local).AddTicks(6521), 2, 2.0, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estacionamento_TabelaPrecoId",
                table: "Estacionamento",
                column: "TabelaPrecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estacionamento_VeiculoId",
                table: "Estacionamento",
                column: "VeiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estacionamento");

            migrationBuilder.DropTable(
                name: "TabelaPreco");

            migrationBuilder.DropTable(
                name: "Veiculo");
        }
    }
}
