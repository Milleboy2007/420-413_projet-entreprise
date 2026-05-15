using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Domaine.Context;
using Domaine.Entity;
using Domaine.Repo;

namespace Domaine.Tests
{
    public class UtilisateurRepositoryTests
    {
        private async Task<ScheduleFlowDBContexte> GetDbContextAsync()
        {
            var options = new DbContextOptionsBuilder<ScheduleFlowDBContexte>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new ScheduleFlowDBContexte(options);
            databaseContext.Database.EnsureCreated();
            return databaseContext;
        }

        private Utilisateur GetValideUtilisateur()
        {
            return new Utilisateur
            {
                Nom = "Doe",
                Prenom = "John",
                Courriel = "john.doe@personnel.com",
                CourrielEntreprise = "john.doe@entreprise.com",
                MotDePasse = "Password123",
                Role = RoleUtilisateur.Employe,
                Genre = "Masculin",
                NumeroTelephoneProfessionnel = "514-000-0000",
                NumeroTelephonePersonnel = "514-111-1111",
                DateNaissance = "1990-01-01",
                Adresse = "123 Rue Principale",
                Ville = "Montréal",
                RegionProvince = "Québec",
                CodePostal = "H1A 1A1",
                Pays = "Canada",
                NomContactUrgence = "Jane Doe",
                TelephoneContactUrgence = "514-222-2222",
                LienParente = "Conjointe",
                DateCreation = DateTime.Now
            };
        }

        /*
         * Test l'obtention d'un utilisateur par Id
         */
        [Fact]
        public async Task ObtenirUtilisateurParId_IdValide_RetourneUtilisateur()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new UtilisateurRepository(dbContext);
            var utilisateur = GetValideUtilisateur();
            repository.AjouterUtilisateur(utilisateur);

            var resultat = repository.ObtenirUtilisateurParId(utilisateur.IdUtilisateur);

            Assert.NotNull(resultat);
            Assert.Equal("john.doe@entreprise.com", resultat.CourrielEntreprise);
        }

        /*
         * Test qu'un utilisateur est bien ajouté
         */
        [Fact]
        public async Task AjouterUtilisateur_NouvelUtilisateur_AjouteASuccess()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new UtilisateurRepository(dbContext);
            var nouvelUtilisateur = GetValideUtilisateur();

            repository.AjouterUtilisateur(nouvelUtilisateur);

            var utilisateurDb = await dbContext.Utilisateurs.FirstOrDefaultAsync();
            Assert.NotNull(utilisateurDb);
            Assert.Equal("john.doe@entreprise.com", utilisateurDb.CourrielEntreprise);
        }

        /*
         * Test l'obtention de tous les utilisateurs
         */
        [Fact]
        public async Task ObtenirUtilisateurs_ListeUtilisateurs_RetourneTousLesUtilisateurs()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new UtilisateurRepository(dbContext);
            var user1 = GetValideUtilisateur();
            var user2 = GetValideUtilisateur();
            user2.CourrielEntreprise = "jane.doe@entreprise.com";

            repository.AjouterUtilisateur(user1);
            repository.AjouterUtilisateur(user2);

            var utilisateurs = repository.ObtenirUtilisateurs();

            Assert.Equal(2, utilisateurs.Count());
        }

        /*
         * Test la validation d'une connexion
         */
        [Fact]
        public async Task VerifierConnexion_IdentifiantsValides_RetourneUtilisateur()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new UtilisateurRepository(dbContext);
            var utilisateur = GetValideUtilisateur();
            repository.AjouterUtilisateur(utilisateur);

            var resultat = repository.VerifierConnexion("john.doe@entreprise.com", "Password123");

            Assert.NotNull(resultat);
            Assert.Equal("john.doe@entreprise.com", resultat.CourrielEntreprise);
        }

        /*
         * Test la modification d'un utilisateur existant
         */
        [Fact]
        public async Task ModifierUtilisateur_UtilisateurValide_ModifieAttributsASuccess()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new UtilisateurRepository(dbContext);
            var utilisateur = GetValideUtilisateur();
            repository.AjouterUtilisateur(utilisateur);

            utilisateur.Prenom = "Peace";
            repository.ModifierUtilisateur(utilisateur);

            var utilisateurDb = await dbContext.Utilisateurs.FindAsync(utilisateur.IdUtilisateur);
            Assert.NotNull(utilisateurDb);
            Assert.Equal("Peace", utilisateurDb.Prenom);
        }

        /*
         * Test la suppression d'un utilisateur
         */
        [Fact]
        public async Task SupprimerUtilisateur_UtilisateurValide_SupprimeDeLaBD()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new UtilisateurRepository(dbContext);
            var utilisateur = GetValideUtilisateur();
            repository.AjouterUtilisateur(utilisateur);

            repository.SupprimerUtilisateur(utilisateur);

            var utilisateurDb = await dbContext.Utilisateurs.FirstOrDefaultAsync();
            Assert.Null(utilisateurDb);
        }

        /*
         * Test le filtrage des employés
         */
        [Fact]
        public async Task ObtenirEmploye_FiltrageRoleEmploye_RetourneUniquementLesEmployes()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new UtilisateurRepository(dbContext);

            var employe = GetValideUtilisateur();
            employe.Role = RoleUtilisateur.Employe;

            var gerant = GetValideUtilisateur();
            gerant.Courriel = "gerant@personnel.com";
            gerant.CourrielEntreprise = "gerant@entreprise.com";
            gerant.Role = RoleUtilisateur.Gerant;

            repository.AjouterUtilisateur(employe);
            repository.AjouterUtilisateur(gerant);

            var resultats = repository.ObtenirEmploye();

            Assert.Single(resultats);
            Assert.Equal(RoleUtilisateur.Employe, resultats.First().Role);
        }
    }
}