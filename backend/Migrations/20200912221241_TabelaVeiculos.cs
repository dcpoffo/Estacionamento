using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class TabelaVeiculos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Veiculo",
                columns: new[] { "Id", "Cor", "Marca", "Modelo", "Placa" },
                values: new object[] { 1, "Azul", "Ford", "New Fiesta", "AAA-1234" });

            migrationBuilder.InsertData(
                table: "Veiculo",
                columns: new[] { "Id", "Cor", "Marca", "Modelo", "Placa" },
                values: new object[] { 2, "Prata", "Chevrolet", "Onix", "BBB-1234" });

            migrationBuilder.InsertData(
                table: "Veiculo",
                columns: new[] { "Id", "Cor", "Marca", "Modelo", "Placa" },
                values: new object[] { 3, "Vermelho", "Fiat", "Uno", "CCC-1234" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veiculo");
        }
    }
}
