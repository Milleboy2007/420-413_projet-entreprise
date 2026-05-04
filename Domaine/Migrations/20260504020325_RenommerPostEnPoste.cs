using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domaine.Migrations
{
    /// <inheritdoc />
    public partial class RenommerPostEnPoste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Post",
                table: "Quarts",
                newName: "Poste");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Poste",
                table: "Quarts",
                newName: "Post");
        }
    }
}
