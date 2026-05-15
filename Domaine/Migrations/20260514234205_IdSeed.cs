using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domaine.Migrations
{
    /// <inheritdoc />
    public partial class IdSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "IdUtilisateur",
                keyValue: 1,
                column: "IdFeuille",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "IdUtilisateur",
                keyValue: 2,
                column: "IdFeuille",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "IdUtilisateur",
                keyValue: 3,
                column: "IdFeuille",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
