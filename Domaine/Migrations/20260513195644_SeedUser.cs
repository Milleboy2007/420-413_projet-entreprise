using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Domaine.Migrations
{
    /// <inheritdoc />
    public partial class SeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdConge",
                table: "DemandeConges",
                newName: "DemandeCongeID");

            migrationBuilder.CreateTable(
                name: "Annonces",
                columns: table => new
                {
                    AnnonceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titre = table.Column<string>(type: "TEXT", nullable: false),
                    Contenu = table.Column<string>(type: "TEXT", nullable: false),
                    Createur = table.Column<int>(type: "INTEGER", nullable: false),
                    DatePublication = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annonces", x => x.AnnonceId);
                });

            migrationBuilder.InsertData(
                table: "Utilisateurs",
                columns: new[] { "IdUtilisateur", "Adresse", "CodePostal", "Courriel", "CourrielEntreprise", "DateCreation", "DateNaissance", "Genre", "LienParente", "MotDePasse", "Nom", "NomContactUrgence", "NumeroTelephonePersonnel", "NumeroTelephoneProfessionnel", "Pays", "Prenom", "RegionProvince", "Role", "TelephoneContactUrgence", "Ville" },
                values: new object[,]
                {
                    { 1, "100 Rue de la Gauchetière", "H3B 2S2", "Employeur@gmail.com", "Employeur@gmail.com", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "13 janvier 1999", "Mâle", "N/A", "1234", "Galvary", "Durocher, Preta", "514-540-420", "514-555-0100", "Canada", "Jean", "Québec", 1, "911", "Montréal" },
                    { 2, "100 Rue de la Gauchetière", "H3B 2S2", "Gerant@gmail.com", "Gerant@gmail.com", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "13 janvier 1999", "Mâle", "N/A", "1234", "Dumets", "Durocher, Preta", "514-540-420", "514-555-0100", "Canada", "Bertrand", "Québec", 0, "911", "Montréal" },
                    { 3, "100 Rue de la Gauchetière", "H3B 2S2", "Employe@gmail.com", "Employe@gmail.com", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "13 janvier 1999", "Mâle", "N/A", "1234", "Rognak", "Durocher, Preta", "514-540-420", "514-555-0100", "Canada", "Claude", "Québec", 2, "911", "Montréal" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annonces");

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "IdUtilisateur",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "IdUtilisateur",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "IdUtilisateur",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "DemandeCongeID",
                table: "DemandeConges",
                newName: "IdConge");
        }
    }
}
