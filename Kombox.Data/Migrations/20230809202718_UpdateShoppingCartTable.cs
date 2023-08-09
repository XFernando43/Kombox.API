using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kombox.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateShoppingCartTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "shoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCarts_IdUser",
                table: "shoppingCarts",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_Usuarios_IdUser",
                table: "shoppingCarts",
                column: "IdUser",
                principalTable: "Usuarios",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_Usuarios_IdUser",
                table: "shoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_shoppingCarts_IdUser",
                table: "shoppingCarts");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "shoppingCarts");
        }
    }
}
