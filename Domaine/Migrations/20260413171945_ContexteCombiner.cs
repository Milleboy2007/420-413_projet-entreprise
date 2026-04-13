using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domaine.Migrations
{
    /// <inheritdoc />
    public partial class ContexteCombiner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DemandeConges",
                columns: table => new
                {
                    IdConge = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUtilisateur = table.Column<int>(type: "INTEGER", nullable: false),
                    DateDebut = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DateFin = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Raison = table.Column<string>(type: "TEXT", nullable: false),
                    Statut = table.Column<string>(type: "TEXT", nullable: false),
                    TypeConge = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Approbateur = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandeConges", x => x.IdConge);
                });

            migrationBuilder.CreateTable(
                name: "FeuilleDispos",
                columns: table => new
                {
                    IdFeuille = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdEmploye = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeuilleDispos", x => x.IdFeuille);
                });

            migrationBuilder.CreateTable(
                name: "Quarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Heure = table.Column<string>(type: "TEXT", nullable: false),
                    Post = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IsPub = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    IdUtilisateur = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: false),
                    Courriel = table.Column<string>(type: "TEXT", nullable: false),
                    CourrielEntreprise = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroTelephoneProfessionnel = table.Column<string>(type: "TEXT", nullable: false),
                    MotDePasse = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroTelephonePersonnel = table.Column<string>(type: "TEXT", nullable: false),
                    DateNaissance = table.Column<string>(type: "TEXT", nullable: false),
                    Adresse = table.Column<string>(type: "TEXT", nullable: false),
                    Ville = table.Column<string>(type: "TEXT", nullable: false),
                    RegionProvince = table.Column<string>(type: "TEXT", nullable: false),
                    CodePostal = table.Column<string>(type: "TEXT", nullable: false),
                    Pays = table.Column<string>(type: "TEXT", nullable: false),
                    NomContactUrgence = table.Column<string>(type: "TEXT", nullable: false),
                    TelephoneContactUrgence = table.Column<string>(type: "TEXT", nullable: false),
                    LienParente = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.IdUtilisateur);
                });

            migrationBuilder.CreateTable(
                name: "CreneauDispos",
                columns: table => new
                {
                    IdCreneau = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdFeuille = table.Column<int>(type: "INTEGER", nullable: false),
                    HeureDebut = table.Column<string>(type: "TEXT", nullable: false),
                    HeureFin = table.Column<string>(type: "TEXT", nullable: false),
                    FeuilleDispoIdFeuille = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreneauDispos", x => x.IdCreneau);
                    table.ForeignKey(
                        name: "FK_CreneauDispos_FeuilleDispos_FeuilleDispoIdFeuille",
                        column: x => x.FeuilleDispoIdFeuille,
                        principalTable: "FeuilleDispos",
                        principalColumn: "IdFeuille");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreneauDispos_FeuilleDispoIdFeuille",
                table: "CreneauDispos",
                column: "FeuilleDispoIdFeuille");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreneauDispos");

            migrationBuilder.DropTable(
                name: "DemandeConges");

            migrationBuilder.DropTable(
                name: "Quarts");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "FeuilleDispos");
        }
    }
}
