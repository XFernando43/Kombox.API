using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kombox.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddFIxedTableRolUserToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Acess",
                table: "RolUsers",
                newName: "Access");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Access",
                table: "RolUsers",
                newName: "Acess");
        }
    }
}
