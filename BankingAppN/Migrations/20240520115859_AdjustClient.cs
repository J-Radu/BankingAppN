using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingAppN.Migrations
{
    /// <inheritdoc />
    public partial class AdjustClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserID",
                table: "Clients",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_UserID",
                table: "Clients",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_UserID",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_UserID",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
