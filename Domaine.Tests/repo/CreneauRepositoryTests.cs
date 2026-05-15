using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Domaine.Context;
using Domaine.Entity;
using Domaine.Repo;

namespace Domaine.Tests.repo
{
    public class CreneauRepositoryTests
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

        // Méthode pour créer un CreneauDispo valide
        private CreneauDispo GetValideCreneauDispo()
        {
            return new CreneauDispo
            {
                IdFeuille = 1,
                Jour = "Lundi",
                HeureDebut = new TimeSpan(8, 0, 0),  // 08:00:00
                HeureFin = new TimeSpan(16, 0, 0)    // 16:00:00

                //---De base---
                // IdCreneau est géré automatiquement par la DB
            };
        }

        /*
         * Test la vérification de l'existence d'un créneau (cas Vrai)
         */
        [Fact]
        public async Task CreneauExiste_CreneauPresentDansDB_RetourneTrue()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new CreneauRepository(dbContext);

            var creneau = GetValideCreneauDispo();
            await dbContext.CreneauDispos.AddAsync(creneau);
            await dbContext.SaveChangesAsync();

            var existe = repository.CreneauExiste(creneau.IdCreneau);

            Assert.True(existe);
        }

        /*
         * Test la vérification de l'existence d'un créneau (cas Faux)
         */
        [Fact]
        public async Task CreneauExiste_CreneauAbsentDeLaDB_RetourneFalse()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new CreneauRepository(dbContext);

            var fakeId = 999;

            var existe = repository.CreneauExiste(fakeId);

            Assert.False(existe);
        }

        /*
         * Test l'ajout d'un nouveau créneau
         */
        [Fact]
        public async Task AjouterCreneau_CreerNouveauCreneau_CreneauAjouteALaDB()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new CreneauRepository(dbContext);
            var nouveauCreneau = GetValideCreneauDispo();

            await repository.AjouterCreneau(nouveauCreneau);

            var creneauEnBase = await dbContext.CreneauDispos.FirstOrDefaultAsync();
            Assert.NotNull(creneauEnBase);
            Assert.Equal("Lundi", creneauEnBase.Jour);
            Assert.Equal(new TimeSpan(8, 0, 0), creneauEnBase.HeureDebut);
        }

        /*
         * Test la modification d'un créneau existant
         */
        [Fact]
        public async Task ModifierCreneau_ModifierCreneauExistant_CreneauMisAJourDansDB()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new CreneauRepository(dbContext);

            var creneau = GetValideCreneauDispo();
            await dbContext.CreneauDispos.AddAsync(creneau);
            await dbContext.SaveChangesAsync();

            creneau.Jour = "Mardi";
            creneau.HeureFin = new TimeSpan(12, 0, 0);
            await repository.ModifierCreneau(creneau);

            var creneauModifie = await dbContext.CreneauDispos.FindAsync(creneau.IdCreneau);
            Assert.NotNull(creneauModifie);
            Assert.Equal("Mardi", creneauModifie.Jour);
            Assert.Equal(new TimeSpan(12, 0, 0), creneauModifie.HeureFin);
        }

        /*
         * Test la suppression d'un créneau existant
         */
        [Fact]
        public async Task SupprimerCreneau_CreneauAjoutePuisSupprime_CreneauSupprimeDeLaDB()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new CreneauRepository(dbContext);

            var creneau = GetValideCreneauDispo();
            await dbContext.CreneauDispos.AddAsync(creneau);
            await dbContext.SaveChangesAsync();

            await repository.SupprimerCreneau(creneau.IdCreneau);

            var creneauDB = await dbContext.CreneauDispos.FindAsync(creneau.IdCreneau);
            Assert.Null(creneauDB);
        }
    }
}