using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingAppN.Migrations
{
    /// <inheritdoc />
    public partial class Adjust : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountNumber",
                table: "AccountOperations",
                newName: "AccountNumberDestination");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountNumberDestination",
                table: "AccountOperations",
                newName: "AccountNumber");
        }
    }
}
