using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kombox.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddItemCartToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_Products_ProductId",
                table: "shoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_Usuarios_IdUser",
                table: "shoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_shoppingCarts_IdUser",
                table: "shoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_shoppingCarts_ProductId",
                table: "shoppingCarts");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "shoppingCarts");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "shoppingCarts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "shoppingCarts");

            migrationBuilder.CreateTable(
                name: "ItemCarts",
                columns: table => new
                {
                    ItemCartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCarts", x => x.ItemCartId);
                    table.ForeignKey(
                        name: "FK_ItemCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarts_ProductId",
                table: "ItemCarts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCarts");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "shoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "shoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "shoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCarts_IdUser",
                table: "shoppingCarts",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCarts_ProductId",
                table: "shoppingCarts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_Products_ProductId",
                table: "shoppingCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_Usuarios_IdUser",
                table: "shoppingCarts",
                column: "IdUser",
                principalTable: "Usuarios",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
