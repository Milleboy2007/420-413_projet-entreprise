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
    {       //Méthode pour créer une fausse DB 
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
                MotDePasse = "12345",
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
         * Test qu'un utilisateur est bien créé
         */
        [Fact]
        public async Task Test_AjouterUtilisateur()
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
         * Test l'obtention de la liste des utilisateurs
         */
        [Fact]
        public async Task Test_ObtenirUtilisateurs()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new UtilisateurRepository(dbContext);

            var user1 = GetValideUtilisateur();
            var user2 = GetValideUtilisateur();
            user2.CourrielEntreprise = "jane.doe@entreprise.com"; 

            repository.AjouterUtilisateur(user1);
            repository.AjouterUtilisateur(user2);

            var utilisateurs = repository.ObtenirUtilisateurs();

            Assert.NotNull(utilisateurs);
            Assert.Equal(2, utilisateurs.Count());
        }

        /*
         * Test qu'une connexion est validée avec des identifiants exacts
         */
        [Fact]
        public async Task Test_VerifierConnexion_Succes()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new UtilisateurRepository(dbContext);

            var utilisateur = GetValideUtilisateur();
            repository.AjouterUtilisateur(utilisateur);

            var resultat = repository.VerifierConnexion("john.doe@entreprise.com", "12345");

            Assert.NotNull(resultat);
            Assert.Equal("john.doe@entreprise.com", resultat.CourrielEntreprise);
        }

        /*
         * Test qu'une connexion est refusée avec de mauvais identifiants
         */
        [Fact]
        public async Task Test_VerifierConnexion_Echec()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new UtilisateurRepository(dbContext);

            var utilisateur = GetValideUtilisateur();
            repository.AjouterUtilisateur(utilisateur);

            var resultat = repository.VerifierConnexion("john.doe@entreprise.com", "1234");

            Assert.Null(resultat);
        }
    }
}