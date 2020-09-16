using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class AlteracaoTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorHoraAdicional",
                table: "TabelaPreco");

            migrationBuilder.UpdateData(
                table: "Estacionamento",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Entrada", "Saida" },
                values: new object[] { new DateTime(2020, 9, 15, 19, 1, 20, 335, DateTimeKind.Local).AddTicks(4560), new DateTime(2020, 9, 15, 19, 11, 20, 336, DateTimeKind.Local).AddTicks(5497) });

            migrationBuilder.UpdateData(
                table: "Estacionamento",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Entrada", "Saida" },
                values: new object[] { new DateTime(2020, 9, 15, 19, 1, 20, 336, DateTimeKind.Local).AddTicks(9378), new DateTime(2020, 9, 15, 19, 36, 20, 336, DateTimeKind.Local).AddTicks(9389) });

            migrationBuilder.UpdateData(
                table: "Estacionamento",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Entrada", "Saida" },
                values: new object[] { new DateTime(2020, 9, 15, 19, 1, 20, 336, DateTimeKind.Local).AddTicks(9516), new DateTime(2020, 9, 15, 22, 1, 20, 336, DateTimeKind.Local).AddTicks(9518) });

            migrationBuilder.UpdateData(
                table: "Estacionamento",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Entrada", "Saida" },
                values: new object[] { new DateTime(2020, 9, 15, 19, 1, 20, 336, DateTimeKind.Local).AddTicks(9549), new DateTime(2020, 9, 15, 21, 1, 20, 336, DateTimeKind.Local).AddTicks(9550) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ValorHoraAdicional",
                table: "TabelaPreco",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Estacionamento",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Entrada", "Saida" },
                values: new object[] { new DateTime(2020, 9, 14, 23, 39, 20, 457, DateTimeKind.Local).AddTicks(7009), new DateTime(2020, 9, 14, 23, 49, 20, 459, DateTimeKind.Local).AddTicks(1452) });

            migrationBuilder.UpdateData(
                table: "Estacionamento",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Entrada", "Saida" },
                values: new object[] { new DateTime(2020, 9, 14, 23, 39, 20, 459, DateTimeKind.Local).AddTicks(6299), new DateTime(2020, 9, 15, 0, 14, 20, 459, DateTimeKind.Local).AddTicks(6311) });

            migrationBuilder.UpdateData(
                table: "Estacionamento",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Entrada", "Saida" },
                values: new object[] { new DateTime(2020, 9, 14, 23, 39, 20, 459, DateTimeKind.Local).AddTicks(6475), new DateTime(2020, 9, 15, 2, 39, 20, 459, DateTimeKind.Local).AddTicks(6478) });

            migrationBuilder.UpdateData(
                table: "Estacionamento",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Entrada", "Saida" },
                values: new object[] { new DateTime(2020, 9, 14, 23, 39, 20, 459, DateTimeKind.Local).AddTicks(6519), new DateTime(2020, 9, 15, 1, 39, 20, 459, DateTimeKind.Local).AddTicks(6521) });

            migrationBuilder.UpdateData(
                table: "TabelaPreco",
                keyColumn: "Id",
                keyValue: 1,
                column: "ValorHoraAdicional",
                value: 1.5);

            migrationBuilder.UpdateData(
                table: "TabelaPreco",
                keyColumn: "Id",
                keyValue: 2,
                column: "ValorHoraAdicional",
                value: 2.0);
        }
    }
}
