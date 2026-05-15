using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Domaine.Context;
using Domaine.Entity;
using Domaine.Repo;
using Domaine.Enum;

namespace Domaine.Tests.repo
{
    public class AnnonceRepositoryTests
    {
        // Méthode pour générer une fausse DB
        private async Task<ScheduleFlowDBContexte> GetDbContextAsync()
        {
            var options = new DbContextOptionsBuilder<ScheduleFlowDBContexte>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new ScheduleFlowDBContexte(options);
            databaseContext.Database.EnsureCreated();
            return databaseContext;
        }

        // Méthode pour créer une Annonce valide
        private Annonce GetValideAnnonce()
        {
            return new Annonce
            {
                Titre = "Annonce Test",
                Contenu = "Contenu de test pour l'annonce.",
                Createur = RoleUtilisateur.Employeur,
                DatePublication = new DateOnly(2026, 5, 14)
            };
        }

        /*
         * Test qu'une annonce est bien publiée (ajoutée a la DB)
         */
        [Fact]
        public async Task PublierAnnonce_CreerNouvelleAnnonce_AnnonceAjouteeALaDB()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new AnnonceRepository(dbContext);
            var nouvelleAnnonce = GetValideAnnonce();

            await repository.PublierAnnonce(nouvelleAnnonce);

            var annonceDB = await dbContext.Annonces.FirstOrDefaultAsync();
            Assert.NotNull(annonceDB);
            Assert.Equal("Annonce Test", annonceDB.Titre);
            Assert.Equal(RoleUtilisateur.Employeur, annonceDB.Createur);
        }

        /*
         * Test la modification d'une annonce existante
         */
        [Fact]
        public async Task ModifierAnnonce_ModifierAnnonceExistante_AnnonceMiseAJourDansDB()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new AnnonceRepository(dbContext);

            var annonce = GetValideAnnonce();
            await dbContext.Annonces.AddAsync(annonce);
            await dbContext.SaveChangesAsync();

            annonce.Titre = "Titre Modifié";
            await repository.ModifierAnnonce(annonce);

            var annonceModifiee = await dbContext.Annonces.FindAsync(annonce.AnnonceId);
            Assert.NotNull(annonceModifiee);
            Assert.Equal("Titre Modifié", annonceModifiee.Titre);
        }

        /*
         * Test de la possibilité de rechercher une annonce par son ID
         */
        [Fact]
        public async Task RechercherAnnonce_ChercherAnnonceExistante_AnnonceDemandeRetournee()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new AnnonceRepository(dbContext);

            var annonce = GetValideAnnonce();
            annonce.Contenu = "Contenu Cible";
            await dbContext.Annonces.AddAsync(annonce);
            await dbContext.SaveChangesAsync();

            var annonceTrouvee = await repository.RechercherAnnonce(annonce.AnnonceId);

            Assert.NotNull(annonceTrouvee);
            Assert.Equal("Contenu Cible", annonceTrouvee.Contenu);
        }

        /*
         * Test la possibilité de supprimer une annonce
         */
        [Fact]
        public async Task SupprimerAnnonce_AnnonceAjouteePuisSupprimee_AnnonceSupprimeeDeLaDB()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new AnnonceRepository(dbContext);

            var annonce = GetValideAnnonce();
            await dbContext.Annonces.AddAsync(annonce);
            await dbContext.SaveChangesAsync();

            await repository.SupprimerAnnonce(annonce.AnnonceId);

            var annonceDB = await dbContext.Annonces.FindAsync(annonce.AnnonceId);
            Assert.Null(annonceDB);
        }

        /*
         * Test la possibilité de récupérer toutes les annonces de la DB
         */
        [Fact]
        public async Task GetAllAnonceAsync_GetToutesLesAnnoncesExistantes_TableauCompletDAnnonces()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new AnnonceRepository(dbContext);

            await dbContext.Annonces.AddAsync(GetValideAnnonce());
            await dbContext.Annonces.AddAsync(GetValideAnnonce());
            await dbContext.SaveChangesAsync();

            var AllAnnonces = await repository.GetAllAnonceAsync();

            Assert.Equal(2, AllAnnonces.Length);
        }
    }
}