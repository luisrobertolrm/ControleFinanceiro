using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiro.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Entrada",
                keyColumn: "ID",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Entrada",
                columns: new[] { "ID", "Data", "Nome", "Valor" },
                values: new object[] { 1, new DateTime(2024, 11, 14, 17, 21, 0, 310, DateTimeKind.Local).AddTicks(7033), "Salário CAST", 8000.01m });
        }
    }
}
