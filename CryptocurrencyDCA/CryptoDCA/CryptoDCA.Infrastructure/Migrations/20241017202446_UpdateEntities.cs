using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoDCA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Investments",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "MonthlyAmount",
                table: "Investments",
                newName: "ValueToday");

            migrationBuilder.AddColumn<decimal>(
                name: "CryptoAmount",
                table: "Investments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InvestedAmount",
                table: "Investments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ROI",
                table: "Investments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentPrice",
                table: "Cryptocurrencies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CryptoAmount",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "InvestedAmount",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "ROI",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "CurrentPrice",
                table: "Cryptocurrencies");

            migrationBuilder.RenameColumn(
                name: "ValueToday",
                table: "Investments",
                newName: "MonthlyAmount");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Investments",
                newName: "StartDate");
        }
    }
}
