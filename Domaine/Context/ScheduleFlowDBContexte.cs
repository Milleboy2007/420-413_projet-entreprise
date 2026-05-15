using Domaine.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.Enum;

namespace Domaine.Context
{
    public class ScheduleFlowDBContexte: DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Quart> Quarts { get; set; }
        public DbSet<FeuilleDispo> FeuilleDispos { get; set; }
        public DbSet<CreneauDispo> CreneauDispos { get; set; }
        public DbSet<DemandeConge> DemandeConges { get; set; }
        public DbSet<Annonce> Annonces { get; set; }

        public ScheduleFlowDBContexte(DbContextOptions<ScheduleFlowDBContexte> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Utilisateur>()
                        .HasOne<FeuilleDispo>()
                        .WithOne()
                        .HasForeignKey<Utilisateur>(u => u.IdFeuille)
                        .IsRequired(false);

            modelBuilder.Entity<Utilisateur>().HasData(
                CreerBaseInfo(1, "Galvary", "Jean", "Employeur@gmail.com", RoleUtilisateur.Employeur, -1),
                CreerBaseInfo(2, "Dumets", "Bertrand", "Gerant@gmail.com", RoleUtilisateur.Gerant, 0),
                CreerBaseInfo(3, "Rognak", "Claude", "Employe@gmail.com", RoleUtilisateur.Employe, 1)
            );
            modelBuilder.Entity<FeuilleDispo>().HasData(
                new FeuilleDispo
                {
                    IdEmploye = 3,
                    IdFeuille = 1
                }
            );
            modelBuilder.Entity<DemandeConge>().HasData(
                new DemandeConge
                {
                    IDDemandeConge = 1,
                    IdEmployee = 3,
                    DateDebut = new DateOnly(2026,06,12),
                    DateFin = new DateOnly(2026,06,15),
                    Motif = "test",
                    TypeConge = "Maladie",
                    Statut = "EnAttente"
                }
            );
        }

        private Utilisateur CreerBaseInfo(int id, string nom, string prenom, string courriel, RoleUtilisateur role, int feuilleId) {
            return new Utilisateur
            {
                IdUtilisateur = id,
                Role = role,
                Nom = nom,
                Prenom = prenom,
                Courriel = courriel,
                CourrielEntreprise = courriel,
                Genre = "Mâle",
                NumeroTelephoneProfessionnel = "514-555-0100",
                MotDePasse = "1234",
                NumeroTelephonePersonnel = "514-540-420",
                DateNaissance = "13 janvier 1999",
                Adresse = "100 Rue de la Gauchetière",
                Ville = "Montréal",
                RegionProvince = "Québec",
                CodePostal = "H3B 2S2",
                Pays = "Canada",
                NomContactUrgence = "Durocher, Preta",
                TelephoneContactUrgence = "911",
                LienParente = "N/A",
                IdFeuille = feuilleId,
                DateCreation = new DateTime(2026, 1, 1)
            };
        }
        
            
    }
}
