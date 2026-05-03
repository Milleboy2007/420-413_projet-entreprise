using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Domaine.Context;
using Domaine.Entity;
using Domaine.Repo;

namespace Domaine.Tests
{
    public class QuartRepositoryTests
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

        // Méthode pour créer un Quart valide
        private Quart GetValideQuart()
        {
            return new Quart
            {
                Date = new DateOnly(2026, 5, 20),
                Heures = [new TimeOnly(8, 0), new TimeOnly(16, 0)],
                Post = "Post Test",
                Description = "Description Test"
                
                //---De base---
                // Id est automatique
                // IsPub = false
                // UserId = null
            };
        }

        /*
         * Test qu'un quart est bien créer
         */
        [Fact]
        public async Task Test_CreateQuartAsync()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new QuartRepository(dbContext);

            var newQuart = GetValideQuart();

            await repository.CreateQuartAsync(newQuart);

            var quart = await dbContext.Quarts.FirstOrDefaultAsync();
            Assert.NotNull(quart);
            Assert.Equal("Description Test", quart.Description);
        }

        /*
         * Test la possibiliter de supprimer un quart
         */
        [Fact]
        public async Task Test_DeleteQuartAsync()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new QuartRepository(dbContext);

            var quart = GetValideQuart();
            await dbContext.Quarts.AddAsync(quart);
            await dbContext.SaveChangesAsync();

            await repository.DeleteQuartAsync(quart.Id);

            var DBquart = await dbContext.Quarts.FindAsync(quart.Id);
            Assert.Null(DBquart);
        }

        /*
         * Test l'assignation d'un utilisateur (ne vérifie pas que l'utilisateur existe)
         */
        [Fact]
        public async Task Test_AssignerUserAsync()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new QuartRepository(dbContext);

            var quart = GetValideQuart();
            await dbContext.Quarts.AddAsync(quart);
            await dbContext.SaveChangesAsync();

            await repository.AssignerUserAsync(quart.Id, 37);

            var DBquart = await dbContext.Quarts.FindAsync(quart.Id);
            Assert.Equal(37, DBquart?.UserId);
        }

        /*
         * Test la publication d'un quart
         */
        [Fact]
        public async Task Test_PublierQuartAsync()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new QuartRepository(dbContext);

            var quart = GetValideQuart();
            await dbContext.Quarts.AddAsync(quart);
            await dbContext.SaveChangesAsync();

            await repository.PublierQuartAsync(quart.Id);

            var DBquart = await dbContext.Quarts.FindAsync(quart.Id);
            Assert.True(DBquart?.IsPub);
        }

        /*
         * Test la posibiliter de récupérer tout les quarts de la DB
         */
        [Fact]
        public async Task Test_GetAllQuartAsync()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new QuartRepository(dbContext);

            await dbContext.Quarts.AddAsync(GetValideQuart());
            await dbContext.Quarts.AddAsync(GetValideQuart());
            await dbContext.SaveChangesAsync();

            var allQuarts = await repository.GetAllQuartAsync();

            Assert.Equal(2, allQuarts.Length);
        }

        /*
         * Test la possibiliter d'obtenir un quart en particularité (avec son id)
         */
        [Fact]
        public async Task Test_GetOneQuartAsync()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new QuartRepository(dbContext);

            var quart = GetValideQuart();
            quart.Description = "Cible";
            await dbContext.Quarts.AddAsync(quart);
            await dbContext.SaveChangesAsync();

            var DBquart = await repository.GetOneQuartAsync(quart.Id);

            Assert.NotNull(DBquart);
            Assert.Equal("Cible", DBquart.Description);
        }

        /*
         * Test la possibiliter de récupérer tout les quarts qui ne sont pas encore assignée
         */
        [Fact]
        public async Task Test_GetAllUnassignateQuartsAsync()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new QuartRepository(dbContext);

            var quartAssigne = GetValideQuart();
            quartAssigne.UserId = 5;

            var quartNonAssigne = GetValideQuart();

            await dbContext.Quarts.AddAsync(quartAssigne);
            await dbContext.Quarts.AddAsync(quartNonAssigne);
            await dbContext.SaveChangesAsync();

            var tabQuartNonAssigne = await repository.GetAllUnassignateQuartsAsync();

            Assert.Single(tabQuartNonAssigne);
            Assert.Null(tabQuartNonAssigne[0].UserId);
        }

        /*
         * Test la possibiliter d'obtenir tout les quarts publier
         */
        [Fact]
        public async Task Test_GetAllPubQuartAsync()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new QuartRepository(dbContext);

            var quartPublier = GetValideQuart();
            quartPublier.IsPub = true;

            var quartNonPublier = GetValideQuart();

            await dbContext.Quarts.AddAsync(quartPublier);
            await dbContext.Quarts.AddAsync(quartNonPublier);
            await dbContext.SaveChangesAsync();

            var tabQuartPub = await repository.GetAllPubQuartAsync();

            Assert.Single(tabQuartPub);
            Assert.True(tabQuartPub[0].IsPub);
        }

        /*
         * Test la possibilité de récupérer tous les quarts pour une date précise
         */
        [Fact]
        public async Task Test_GetAllQuartByDate()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new QuartRepository(dbContext);

            var dateCible = new DateOnly(2026, 5, 20);

            var quartCible1 = GetValideQuart();
            var quartCible2 = GetValideQuart();

            var quartAutreDate = GetValideQuart();
            quartAutreDate.Date = new DateOnly(2026, 12, 25);

            await dbContext.Quarts.AddAsync(quartCible1);
            await dbContext.Quarts.AddAsync(quartCible2);
            await dbContext.Quarts.AddAsync(quartAutreDate);
            await dbContext.SaveChangesAsync();

            var resultats = await repository.GetAllQuartByDateAsync(dateCible);

            Assert.Equal(2, resultats.Length);
            Assert.All(resultats, quart => Assert.Equal(dateCible, quart.Date));
        }
    }
}