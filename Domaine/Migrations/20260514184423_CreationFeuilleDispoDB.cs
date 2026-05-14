using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domaine.Migrations
{
    /// <inheritdoc />
    public partial class CreationFeuilleDispoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FeuilleDispos",
                columns: new[] { "IdFeuille", "IdEmploye" },
                values: new object[] { 1, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FeuilleDispos",
                keyColumn: "IdFeuille",
                keyValue: 1);
        }
    }
}
