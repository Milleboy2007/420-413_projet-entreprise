using Domaine.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Domaine.Context
{
    internal class ScheduleFlowDbContext
    {
        public DbSet<Gerant> gerants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=gerants.db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Gerant>(entity =>
            {
                entity.ToTable("Gerants");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Nom).IsRequired();
                entity.Property(t => t.Prenom).IsRequired();
                entity.Property(t => t.Email).IsRequired();
                entity.Property(t => t.Pass).IsRequired();
                entity.Property(t => t.Tel).IsRequired();
                entity.Property(t => t.Naissance).IsRequired();
                entity.Property(t => t.Poste).IsRequired();
                entity.Property(t => t.Depart).IsRequired();
                entity.Property(t => t.TypeContrat).IsRequired();
                entity.Property(t => t.AdrPost).IsRequired();
                entity.Property(t => t.Pays).IsRequired();
                entity.Property(t => t.Prov).IsRequired();
                entity.Property(t => t.Ville).IsRequired();
                entity.Property(t => t.CodePost).IsRequired();
                entity.Property(t => t.NomContUrg).IsRequired();
                entity.Property(t => t.NumContUrg).IsRequired();
                entity.Property(t => t.LienContUrg).IsRequired();
                entity.Property(t => t.FormSupp);

                // Seed data (données initiales)
                entity.HasData(
                    new Gerant { Id = 1, Nom = "Bertrand", Prenom = "Gilbert", Email = "kyky@gmail.com", Pass = "abc123", Tel = "4385776885", Naissance = "14 juin 2000", Poste = "Gerant d'inventaire", Depart = "Inventaire", TypeContrat = "Permanent", AdrPost = "899 4e avenue", Pays = "Canada", Prov = "Québec", Ville = "Pointe-Aux-Trembles", CodePost = "H15 9K4", NomContUrg = "Billy Umma", NumContUrg = "5148557444", FormSupp = "", LienContUrg = "frère" }
                );
            });
        }

    }
}
