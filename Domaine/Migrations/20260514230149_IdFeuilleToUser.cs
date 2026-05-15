using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domaine.Migrations
{
    /// <inheritdoc />
    public partial class IdFeuilleToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdFeuille",
                table: "Utilisateurs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "IdUtilisateur",
                keyValue: 1,
                column: "IdFeuille",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "IdUtilisateur",
                keyValue: 2,
                column: "IdFeuille",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "IdUtilisateur",
                keyValue: 3,
                column: "IdFeuille",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdFeuille",
                table: "Utilisateurs");
        }
    }
}
