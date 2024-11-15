using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiro.Database.Migrations
{
    /// <inheritdoc />
    public partial class BancoBaseOK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Entrada",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Entrada",
                newName: "Descricao");

            migrationBuilder.AddColumn<int>(
                name: "Ano",
                table: "Entrada",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTipoEntrada",
                table: "Entrada",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mes",
                table: "Entrada",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Periodo",
                columns: table => new
                {
                    Ano = table.Column<int>(type: "INTEGER", nullable: false),
                    Mes = table.Column<int>(type: "INTEGER", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodo", x => new { x.Ano, x.Mes });
                });

            migrationBuilder.CreateTable(
                name: "TipoEntrada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEntrada", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoSaida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSaida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Saida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false),
                    Mes = table.Column<int>(type: "INTEGER", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    IdTipoSaida = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Saida_Periodo_Ano_Mes",
                        columns: x => new { x.Ano, x.Mes },
                        principalTable: "Periodo",
                        principalColumns: new[] { "Ano", "Mes" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Saida_TipoSaida_IdTipoSaida",
                        column: x => x.IdTipoSaida,
                        principalTable: "TipoSaida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaidaItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdSaida = table.Column<int>(type: "INTEGER", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    IdTipoSaida = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaidaItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaidaItem_Saida_IdSaida",
                        column: x => x.IdSaida,
                        principalTable: "Saida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_Ano_Mes",
                table: "Entrada",
                columns: new[] { "Ano", "Mes" });

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_IdTipoEntrada",
                table: "Entrada",
                column: "IdTipoEntrada");

            migrationBuilder.CreateIndex(
                name: "IX_Saida_Ano_Mes",
                table: "Saida",
                columns: new[] { "Ano", "Mes" });

            migrationBuilder.CreateIndex(
                name: "IX_Saida_IdTipoSaida",
                table: "Saida",
                column: "IdTipoSaida");

            migrationBuilder.CreateIndex(
                name: "IX_SaidaItem_IdSaida",
                table: "SaidaItem",
                column: "IdSaida");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_Periodo_Ano_Mes",
                table: "Entrada",
                columns: new[] { "Ano", "Mes" },
                principalTable: "Periodo",
                principalColumns: new[] { "Ano", "Mes" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_TipoEntrada_IdTipoEntrada",
                table: "Entrada",
                column: "IdTipoEntrada",
                principalTable: "TipoEntrada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_Periodo_Ano_Mes",
                table: "Entrada");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_TipoEntrada_IdTipoEntrada",
                table: "Entrada");

            migrationBuilder.DropTable(
                name: "SaidaItem");

            migrationBuilder.DropTable(
                name: "TipoEntrada");

            migrationBuilder.DropTable(
                name: "Saida");

            migrationBuilder.DropTable(
                name: "Periodo");

            migrationBuilder.DropTable(
                name: "TipoSaida");

            migrationBuilder.DropIndex(
                name: "IX_Entrada_Ano_Mes",
                table: "Entrada");

            migrationBuilder.DropIndex(
                name: "IX_Entrada_IdTipoEntrada",
                table: "Entrada");

            migrationBuilder.DropColumn(
                name: "Ano",
                table: "Entrada");

            migrationBuilder.DropColumn(
                name: "IdTipoEntrada",
                table: "Entrada");

            migrationBuilder.DropColumn(
                name: "Mes",
                table: "Entrada");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Entrada",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Entrada",
                newName: "Nome");
        }
    }
}
