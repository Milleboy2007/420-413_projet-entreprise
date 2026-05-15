using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Domaine.Context;
using Domaine.Entity;
using Domaine.Repo;

namespace Domaine.Tests.repo
{
    public class DispoRepositoryTests
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

        // Méthode pour créer une FeuilleDispo valide
        private FeuilleDispo GetValideFeuilleDispo()
        {
            return new FeuilleDispo
            {
                IdEmploye = 42

                //---De base---
                // IdFeuille est géré par la base de données (auto-incrément)
                // Creneaux est initialisé comme une liste vide par le constructeur de l'entité
            };
        }

        /*
         * Test la vérification de l'existence d'une feuille de disponibilité (cas Vrai)
         */
        [Fact]
        public async Task FeuilleDispoExiste_FeuillePresenteDansDB_RetourneTrue()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new DispoRepository(dbContext);

            var feuille = GetValideFeuilleDispo();
            await dbContext.FeuilleDispos.AddAsync(feuille);
            await dbContext.SaveChangesAsync();

            var existe = repository.FeuilleDispoExiste(feuille.IdFeuille);

            Assert.True(existe);
        }

        /*
         * Test la vérification de l'existence d'une feuille de disponibilité (cas Faux)
         */
        [Fact]
        public async Task FeuilleDispoExiste_FeuilleAbsenteDeLaDB_RetourneFalse()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new DispoRepository(dbContext);

            var fakeId = 999;

            var existe = repository.FeuilleDispoExiste(fakeId);

            Assert.False(existe);
        }

        /*
         * Test l'ajout d'une nouvelle feuille de disponibilité
         */
        [Fact]
        public async Task AjouterDispo_CreerNouvelleDispo_DispoAjouteeALaDB()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new DispoRepository(dbContext);
            var nouvelleFeuille = GetValideFeuilleDispo();

            await repository.AjouterDispo(nouvelleFeuille);

            var feuilleDB = await dbContext.FeuilleDispos.FirstOrDefaultAsync();
            Assert.NotNull(feuilleDB);
            Assert.Equal(42, feuilleDB.IdEmploye);
        }

        /*
         * Test la modification d'une feuille de disponibilité existante
         */
        [Fact]
        public async Task ModifierDispo_ModifierDispoExistante_DispoMiseAJourDansDB()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new DispoRepository(dbContext);

            var feuille = GetValideFeuilleDispo();
            await dbContext.FeuilleDispos.AddAsync(feuille);
            await dbContext.SaveChangesAsync();

            // Modification
            feuille.IdEmploye = 99;
            await repository.ModifierDispo(feuille);

            var feuilleModifiee = await dbContext.FeuilleDispos.FindAsync(feuille.IdFeuille);
            Assert.NotNull(feuilleModifiee);
            Assert.Equal(99, feuilleModifiee.IdEmploye);
        }

        /*
         * Test la suppression d'une feuille de disponibilité existante
         */
        [Fact]
        public async Task SupprimerDispo_DispoAjouteePuisSupprimee_DispoSupprimeeDeLaDB()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new DispoRepository(dbContext);

            var feuille = GetValideFeuilleDispo();
            await dbContext.FeuilleDispos.AddAsync(feuille);
            await dbContext.SaveChangesAsync();

            await repository.SupprimerDispo(feuille.IdFeuille);

            var feuilleEnBase = await dbContext.FeuilleDispos.FindAsync(feuille.IdFeuille);
            Assert.Null(feuilleEnBase);
        }
    }
}