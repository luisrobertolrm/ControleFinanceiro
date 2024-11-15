using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiro.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Entrada",
                keyColumn: "ID",
                keyValue: 1,
                column: "Data",
                value: new DateTime(2024, 11, 14, 17, 21, 0, 310, DateTimeKind.Local).AddTicks(7033));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Entrada",
                keyColumn: "ID",
                keyValue: 1,
                column: "Data",
                value: new DateTime(2024, 11, 14, 17, 20, 14, 80, DateTimeKind.Local).AddTicks(438));
        }
    }
}
