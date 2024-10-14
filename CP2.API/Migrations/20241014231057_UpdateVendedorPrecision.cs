using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CP2.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVendedorPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MetaMensal",
                table: "Vendedores",
                type: "DECIMAL(12,2)",
                precision: 12,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ComissaoPercentual",
                table: "Vendedores",
                type: "DECIMAL(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MetaMensal",
                table: "Vendedores",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(12,2)",
                oldPrecision: 12,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "ComissaoPercentual",
                table: "Vendedores",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,2)",
                oldPrecision: 10,
                oldScale: 2);
        }
    }
}
