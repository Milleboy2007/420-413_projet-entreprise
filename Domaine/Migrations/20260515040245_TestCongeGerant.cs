using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domaine.Migrations
{
    /// <inheritdoc />
    public partial class TestCongeGerant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Raison",
                table: "DemandeConges",
                newName: "Motif");

            migrationBuilder.RenameColumn(
                name: "IdUtilisateur",
                table: "DemandeConges",
                newName: "IdEmployee");

            migrationBuilder.RenameColumn(
                name: "DemandeCongeID",
                table: "DemandeConges",
                newName: "IDDemandeConge");

            migrationBuilder.InsertData(
                table: "DemandeConges",
                columns: new[] { "IDDemandeConge", "Approbateur", "DateCreation", "DateDebut", "DateFin", "IdEmployee", "Motif", "Statut", "TypeConge" },
                values: new object[] { 1, 0, new DateTime(2026, 5, 15, 0, 2, 44, 934, DateTimeKind.Local).AddTicks(6084), new DateOnly(2026, 6, 12), new DateOnly(2026, 6, 15), 3, "test", "EnAttente", "Maladie" });

            migrationBuilder.CreateIndex(
                name: "IX_DemandeConges_IdEmployee",
                table: "DemandeConges",
                column: "IdEmployee");

            migrationBuilder.AddForeignKey(
                name: "FK_DemandeConges_Utilisateurs_IdEmployee",
                table: "DemandeConges",
                column: "IdEmployee",
                principalTable: "Utilisateurs",
                principalColumn: "IdUtilisateur",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DemandeConges_Utilisateurs_IdEmployee",
                table: "DemandeConges");

            migrationBuilder.DropIndex(
                name: "IX_DemandeConges_IdEmployee",
                table: "DemandeConges");

            migrationBuilder.DeleteData(
                table: "DemandeConges",
                keyColumn: "IDDemandeConge",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Motif",
                table: "DemandeConges",
                newName: "Raison");

            migrationBuilder.RenameColumn(
                name: "IdEmployee",
                table: "DemandeConges",
                newName: "IdUtilisateur");

            migrationBuilder.RenameColumn(
                name: "IDDemandeConge",
                table: "DemandeConges",
                newName: "DemandeCongeID");
        }
    }
}
