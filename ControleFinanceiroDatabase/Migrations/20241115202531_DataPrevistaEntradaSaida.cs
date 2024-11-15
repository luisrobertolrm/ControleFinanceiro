using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiro.Database.Migrations
{
    /// <inheritdoc />
    public partial class DataPrevistaEntradaSaida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "TipoSaida",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "TipoEntrada",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "SaidaItem",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "Saida",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataProjetada",
                table: "Saida",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "Entrada",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataProjetada",
                table: "Entrada",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "TipoSaida");

            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "TipoEntrada");

            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "SaidaItem");

            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "Saida");

            migrationBuilder.DropColumn(
                name: "DataProjetada",
                table: "Saida");

            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "Entrada");

            migrationBuilder.DropColumn(
                name: "DataProjetada",
                table: "Entrada");
        }
    }
}
