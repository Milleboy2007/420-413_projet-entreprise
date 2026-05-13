using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domaine.Migrations
{
    /// <inheritdoc />
    public partial class RenommerHeureEnHeures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Heure",
                table: "Quarts",
                newName: "Heures");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Heures",
                table: "Quarts",
                newName: "Heure");
        }
    }
}
