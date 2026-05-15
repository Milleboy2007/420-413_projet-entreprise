using Microsoft.EntityFrameworkCore;
using Domaine.Context;
using Domaine.Entity;
using Domaine.Repo;
using Domaine.Enum;

namespace Domaine.Tests.repo
{
    public class DemandeCongeRepositoryTests
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

        // Méthode pour créer une DemandeConge valide
        private DemandeConge GetValideDemandeConge()
        {
            return new DemandeConge
            {
                IdEmployee = 1,
                DateDebut = new DateOnly(2026, 6, 1),
                DateFin = new DateOnly(2026, 6, 15),
                Motif = "Vacances annuelles",
                TypeConge = "Vacances",
                Approbateur = RoleUtilisateur.Employeur

                //---De base---
                // DemandeCongeID est automatique
                // DateCreation est automatique (constructeur)
                // Statut par défaut : EtatStatut.EnAttente.ToString() (constructeur)
            };
        }

        /*
         * Test qu'une demande de congé est bien créée et ajoutée à la base de données
         */
        [Fact]
        public async Task AjouterDemandeCongeAsync_CreerNouvelleDemande_DemandeAjouteeALaDB()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new DemandeCongeRepository(dbContext);
            var nouvelleDemande = GetValideDemandeConge();

            await repository.AjouterDemandeCongeAsync(nouvelleDemande);

            var demandeEnBase = await dbContext.DemandeConges.FirstOrDefaultAsync();
            Assert.NotNull(demandeEnBase);
            Assert.Equal("Vacances annuelles", demandeEnBase.Motif);
            Assert.Equal(1, demandeEnBase.IdEmployee);
            Assert.Equal(EtatStatut.EnAttente.ToString(), demandeEnBase.Statut);
        }

        /*
         * Test la modification d'une demande de congé existante
         */
        [Fact]
        public async Task ModifierDemandeCongeAsync_ModifierDemandeExistante_DemandeMiseAJourDansDB()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new DemandeCongeRepository(dbContext);

            var demande = GetValideDemandeConge();
            await dbContext.DemandeConges.AddAsync(demande);
            await dbContext.SaveChangesAsync();

            demande.Motif = "Raison Modifiée";
            demande.Statut = EtatStatut.Approuve.ToString();
            await repository.ModifierDemandeCongeAsync(demande);

            var demandeModifiee = await dbContext.DemandeConges.FindAsync(demande.IDDemandeConge);
            Assert.NotNull(demandeModifiee);
            Assert.Equal("Raison Modifiée", demandeModifiee.Motif);
            Assert.Equal(EtatStatut.Approuve.ToString(), demandeModifiee.Statut);
        }

        /*
         * Test la recherche d'une demande de congé existante par son ID
         */
        [Fact]
        public async Task RechercherParIdAsync_ChercherDemandeExistanteParId_DemandeDemanderRetourner()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new DemandeCongeRepository(dbContext);

            var demande = GetValideDemandeConge();
            demande.Motif = "Demande Cible";
            await dbContext.DemandeConges.AddAsync(demande);
            await dbContext.SaveChangesAsync();

            var demandeTrouvee = await repository.RechercherParIdAsync(demande.IDDemandeConge);

            Assert.NotNull(demandeTrouvee);
            Assert.Equal("Demande Cible", demandeTrouvee.Motif);
        }

        /*
         * Test de la suppression d'une demande de congé existante par son ID
         */
        [Fact]
        public async Task SupprimerDemandeCongeAsync_DemandeAjouteePuisSupprimee_DemandeSupprimeeDeLaDB()
        {
            var dbContext = await GetDbContextAsync();
            var repository = new DemandeCongeRepository(dbContext);

            var demande = GetValideDemandeConge();
            await dbContext.DemandeConges.AddAsync(demande);
            await dbContext.SaveChangesAsync();

            await repository.SupprimerDemandeCongeAsync(demande.IDDemandeConge);

            var demandeDB = await dbContext.DemandeConges.FindAsync(demande.IDDemandeConge);
            Assert.Null(demandeDB);
        }
    }
}